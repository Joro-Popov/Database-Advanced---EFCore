namespace Employees.App.Commands
{
    using Employees.App.Constants;
    using Employees.App.Controllers.Contracts;
    using System;
    using System.Collections.Generic;

    public class SetBirthdayCommand : Command
    {
        public SetBirthdayCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var date = DateTime.ParseExact(arguments[1], "dd-MM-yyyy", null);

            this.EmployeesController.SetBirthday(employeeId, date);

            return Messages.SuccessfullAddDate;
        }
    }
}