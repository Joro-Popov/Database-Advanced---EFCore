namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DTOs;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(a => a.Passport.OwnerPhoneNumber == phoneNumber)
                .OrderBy(a => a.Age)
                .Select(a => new ExportAnimalDto
                {
                    OwnerName = a.Passport.OwnerName,
                    AnimalName = a.Name,
                    Age = a.Age,
                    SerialNumber = a.PassportSerialNumber,
                    RegisteredOn = a.Passport.RegistrationDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                }).ToList();

            var jsonString = JsonConvert.SerializeObject(animals, Formatting.Indented);

            return jsonString;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var serializer = new XmlSerializer(typeof(List<ExportProcedureDto>), new XmlRootAttribute("Procedures"));
            var namespaces = new XmlSerializerNamespaces(new[] { new System.Xml.XmlQualifiedName("", "") });

            var procedures = context.Procedures
                .OrderBy(p => p.DateTime)
                .ThenBy(p => p.Animal.PassportSerialNumber)
                .Select(p => new ExportProcedureDto
                {
                    Passport = p.Animal.PassportSerialNumber,
                    OwnerNumber = p.Animal.Passport.OwnerPhoneNumber,
                    DateTime = p.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    AnimalAids = p.ProcedureAnimalAids
                    .Select(aid => new ExportAnimalAidDto
                    {
                        Name = aid.AnimalAid.Name,
                        Price = aid.AnimalAid.Price
                    }).ToList(),
                    TotalPrice = p.ProcedureAnimalAids.Sum(x => x.AnimalAid.Price)
                }).ToList();

            var result = new StringBuilder();

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, procedures, namespaces);
            }

            return result.ToString().Trim();
        }
    }
}
