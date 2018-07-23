namespace Employees.App.Commands
{
    using Employees.App.Controllers.Contracts;
    using System;
    using System.Collections.Generic;

    public class ExitCommand : Command
    {
        public ExitCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            Environment.Exit(0);
            return "";
        }
    }
}