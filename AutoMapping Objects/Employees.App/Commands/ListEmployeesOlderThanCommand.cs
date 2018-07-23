namespace Employees.App.Commands
{
    using Employees.App.Controllers.Contracts;
    using System;
    using System.Collections.Generic;

    public class ListEmployeesOlderThanCommand : Command
    {
        public ListEmployeesOlderThanCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var age = int.Parse(arguments[0]);

            var employees = this.EmployeesController.ListEmployeesOlderThan(age);

            return string.Join(Environment.NewLine, employees);
        }
    }
}