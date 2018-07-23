namespace Employees.App.DTOModels
{
    using System;
    using System.Text;

    public class EmployeePersonalInfoDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"ID: {this.EmployeeId} - {this.FirstName} {this.LastName} - ${this.Salary:f2}");
            result.AppendLine($"Birthday: {this.Birthday.ToString("dd-MM-yyyy")}");
            result.AppendLine($"Address: {this.Address}");

            return result.ToString().Trim();
        }
    }
}