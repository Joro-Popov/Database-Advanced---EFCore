namespace Employees.App.Commands
{
    using Employees.App.Controllers.Contracts;
    using System.Collections.Generic;

    public class EmployeePersonalInfoCommand : Command
    {
        public EmployeePersonalInfoCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var employeeId = int.Parse(arguments[0]);

            var employee = this.EmployeesController.GetEmployeePersonalInfo(employeeId);

            return employee.ToString();
        }
    }
}