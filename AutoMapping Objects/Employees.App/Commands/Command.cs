namespace Employees.App.Commands
{
    using Employees.App.Commands.Contracts;
    using Employees.App.Controllers.Contracts;
    using System.Collections.Generic;

    public abstract class Command : ICommand
    {
        private readonly IEmployeesController employeesController;

        public Command(IEmployeesController employeesController)
        {
            this.employeesController = employeesController;
        }

        protected IEmployeesController EmployeesController => this.employeesController;

        public abstract string Execute(IList<string> arguments);
    }
}