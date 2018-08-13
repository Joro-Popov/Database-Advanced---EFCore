namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Any(i => i == p.Id))
                .Select(p => new
                {
                    p.Id,
                    Name = p.FullName,
                    p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                    .Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(o => o.OfficerName)
                    .ToList(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(o => o.Officer.Salary),2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var jsonString = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonString;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonerNames = prisonersNames
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<PrisonerDto>), new XmlRootAttribute("Prisoners"));
            var namespaces = new XmlSerializerNamespaces(new[] { new System.Xml.XmlQualifiedName("", "") });

            var prisoners = context.Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(p => new PrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails
                    .Select(m => new EncryptedMessageDto
                    {
                        Description = Reverse(m.Description)
                    }).ToList()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToList();

            var result = new StringBuilder();

            using (var writer = new StringWriter(result))
            {
                serializer.Serialize(writer, prisoners, namespaces);
            }

            return result.ToString().Trim();
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}