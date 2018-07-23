namespace Employees.App.Commands
{
    using Employees.App.Constants;
    using Employees.App.Controllers.Contracts;
    using Employees.App.DTOModels;
    using System.Collections.Generic;

    public class AddEmployeeCommand : Command
    {
        public AddEmployeeCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var firstName = arguments[0];
            var lastName = arguments[1];
            var salary = decimal.Parse(arguments[2]);

            var employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.EmployeesController.AddEmployee(employeeDto);

            return Messages.SuccessfullAdd;
        }
    }
}