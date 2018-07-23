namespace Employees.App.DTOModels
{
    using System.Collections.Generic;
    using System.Text;

    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeesCount { get; set; }

        public ICollection<EmployeeDto> ManagedEmployees { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.FirstName} {this.LastName} | Employees: {this.EmployeesCount}");

            foreach (var emp in this.ManagedEmployees)
            {
                result.AppendLine($"    - {emp.FirstName} {emp.LastName} - ${emp.Salary:f2}");
            }

            return result.ToString().Trim();
        }
    }
}