namespace Employees.App.Commands
{
    using Employees.App.Controllers.Contracts;
    using System.Collections.Generic;

    public class SetManagerCommand : Command
    {
        public SetManagerCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var managerId = int.Parse(arguments[1]);

            var result = this.EmployeesController.SetManager(employeeId, managerId);

            return result;
        }
    }
}