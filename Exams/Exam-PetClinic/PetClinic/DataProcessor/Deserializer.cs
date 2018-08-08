namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DTOs;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializedAnimalAids = JsonConvert.DeserializeObject<AnimalAid[]>(jsonString);

            var animalAids = new List<AnimalAid>();

            foreach (var aid in deserializedAnimalAids)
            {
                var aidExists = animalAids.Any(a => a.Name == aid.Name);

                if (!IsValid(aid) || aidExists)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }
                
                animalAids.Add(aid);

                sb.AppendLine($"Record {aid.Name} successfully imported.");
            }

            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var deserializedAnimals = JsonConvert.DeserializeObject<AnimalDto[]>(jsonString);

            var sb = new StringBuilder();
            var animals = new List<Animal>();
            
            foreach (var animal in deserializedAnimals)
            {
                var passportExists = animals.Any(p => p.Passport.SerialNumber == animal.Passport.SerialNumber);

                if (!IsValid(animal) || !IsValid(animal.Passport) || passportExists)
                {
                    sb.AppendLine("Error: Invalid data.");
                    continue;
                }

                var current = new Animal
                {
                    Name = animal.Name,
                    Type = animal.Type,
                    Age = animal.Age,
                    PassportSerialNumber = animal.Passport.SerialNumber,
                    Passport = new Passport
                    {
                        SerialNumber = animal.Passport.SerialNumber,
                        OwnerName = animal.Passport.OwnerName,
                        OwnerPhoneNumber = animal.Passport.OwnerPhoneNumber,
                        RegistrationDate = DateTime.ParseExact(animal.Passport.RegistrationDate, "dd-MM-yyyy", null)
                    }
                };

                animals.Add(current);

                sb.AppendLine($"Record {animal.Name} Passport №: {animal.Passport.SerialNumber} successfully imported.");
            }

            context.Animals.AddRange(animals);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<VetDto>), new XmlRootAttribute("Vets"));

            var deserializedVets = (List<VetDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var vets = new List<Vet>();

            foreach (var vet in deserializedVets)
            {
                var validVet = IsValid(vet);
                var validPhoneNumber = vets.Any(v => v.PhoneNumber == vet.PhoneNumber);

                if (!validVet || validPhoneNumber)
                {
                    sb.AppendLine($"Error: Invalid data.");
                    continue;
                }

                var current = new Vet
                {
                    Name = vet.Name,
                    Profession = vet.Profession,
                    Age = vet.Age,
                    PhoneNumber = vet.PhoneNumber
                };

                vets.Add(current);

                sb.AppendLine($"Record {vet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<ProcedureDto>), new XmlRootAttribute("Procedures"));

            var deserializedProcedures = (List<ProcedureDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var procedures = new List<Procedure>();

            foreach (var proc in deserializedProcedures)
            {
                var vetExists = context.Vets.Any(v => v.Name == proc.VetName); 
                var animalExists = context.Animals.Any(a => a.PassportSerialNumber == proc.AnimalPassportNumber); 
                var aidExists = context.AnimalAids.Any(a => proc.AnimalAids.Any(aid => aid.Name == a.Name));
                var sameAidGivven = false;
                var validProc = IsValid(proc);

                foreach (var aid in proc.AnimalAids)
                {
                    var current = aid.Name;
                    var moreThanOnce = proc.AnimalAids.Where(a => a.Name == current).Count() > 1;

                    if (moreThanOnce)
                    {
                        sameAidGivven = true;
                    }
                }

                if (!vetExists || !animalExists || !aidExists || sameAidGivven || !validProc)
                {
                    sb.AppendLine($"Error: Invalid data.");
                    continue;
                }

                var procedure = new Procedure
                {
                    Vet = context.Vets.FirstOrDefault(v => v.Name == proc.VetName),
                    AnimalId = context.Animals.FirstOrDefault(a => a.PassportSerialNumber == proc.AnimalPassportNumber).Id,
                    DateTime = DateTime.ParseExact(proc.DateTime, "dd-MM-yyyy", null),
                    ProcedureAnimalAids = proc.AnimalAids.Select(x => new ProcedureAnimalAid
                    {
                        AnimalAid = context.AnimalAids.FirstOrDefault(a => a.Name == x.Name),
                        Procedure = context.Procedures.FirstOrDefault(p => p.Id == proc.Id)
                    }).ToList()
                };

                procedures.Add(procedure);
                sb.AppendLine("Record successfully imported.");
            }

            context.AddRange(procedures);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
