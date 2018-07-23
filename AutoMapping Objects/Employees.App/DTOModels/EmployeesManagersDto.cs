namespace Employees.App.DTOModels
{
    public class EmployeesManagersDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerName { get; set; }

        public override string ToString()
        {
            var result = $"{this.FirstName} {this.LastName} - ${this.Salary:f2}: {this.ManagerName ?? "[no manager]"}";

            return result;
        }
    }
}