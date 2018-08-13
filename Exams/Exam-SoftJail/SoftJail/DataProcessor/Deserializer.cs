namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var deserializedCells = JsonConvert.DeserializeObject<List<DepartmentCellDto>>(jsonString);

            var sb = new StringBuilder();

            var validDeptCells = new List<Department>();

            foreach (var deptCell in deserializedCells)
            {
                var isvalidCell = true;

                foreach (var cell in deptCell.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isvalidCell = false;
                    }
                }

                if (!IsValid(deptCell) || !isvalidCell)
                {
                    sb.AppendLine($"Invalid Data");
                    continue;
                }

                var current = new Department
                {
                    Name = deptCell.Name,
                    Cells = deptCell.Cells.Select(c => new Cell
                    {
                        CellNumber = c.CellNumber,
                        HasWindow = c.HasWindow
                    }).ToList(),
                };

                if (!IsValid(current) || !isvalidCell)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                validDeptCells.Add(current);
                sb.AppendLine($"Imported {current.Name} with {current.Cells.Count()} cells");
            }

            context.Departments.AddRange(validDeptCells);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var deserializedPrisoners = JsonConvert.DeserializeObject<List<PrisonerDto>>(jsonString);

            var sb = new StringBuilder();

            var validPrisoners = new List<Prisoner>();

            foreach (var prisoner in deserializedPrisoners)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var AreAddressesValid = true;

                foreach (var mail in prisoner.Mails)
                {
                    if (!IsValid(mail))
                    {
                        AreAddressesValid = false;
                        break;
                    }
                }

                if (!AreAddressesValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime? releaseDate;

                try
                {
                    releaseDate = DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    releaseDate = null;
                }

                var current = new Prisoner
                {
                    FullName = prisoner.FullName,
                    Nickname = prisoner.Nickname,
                    Age = prisoner.Age,
                    IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = releaseDate,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    Mails = prisoner.Mails.Select(m => new Mail
                    {
                        Description = m.Description,
                        Sender = m.Sender,
                        Address = m.Address
                    }).ToList()
                };

                validPrisoners.Add(current);
                sb.AppendLine($"Imported {current.FullName} {current.Age} years old");
            }

            context.Prisoners.AddRange(validPrisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<OfficerDto>), new XmlRootAttribute("Officers"));

            var deserializedOfficers = (List<OfficerDto>)serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();

            var validOfficers = new List<Officer>();

            foreach (var officer in deserializedOfficers)
            {
                var validPosition = Enum.TryParse(officer.Position, out Position pos);
                var validWeapon = Enum.TryParse(officer.Weapon, out Weapon wep);

                if (!IsValid(officer) || !validPosition || !validWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var current = new Officer
                {
                    FullName = officer.Name,
                    Salary = officer.Salary,
                    Position = (Position)Enum.Parse(typeof(Position), officer.Position, true),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon), officer.Weapon, true),
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners
                    .Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.Id,
                        OfficerId = officer.Id
                    }).ToList()
                };

                validOfficers.Add(current);
                sb.AppendLine($"Imported {current.FullName} ({current.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(validOfficers);
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