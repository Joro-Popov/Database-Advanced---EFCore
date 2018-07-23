namespace Employees.App.Commands
{
    using Employees.App.Controllers.Contracts;
    using System.Collections.Generic;

    public class ManagerInfoCommand : Command
    {
        public ManagerInfoCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var employeeId = int.Parse(arguments[0]);

            var result = this.EmployeesController.GetManagerInfo(employeeId);

            return result.ToString();
        }
    }
}