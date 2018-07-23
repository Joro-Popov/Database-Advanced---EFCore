namespace Employees.App.Commands
{
    using Employees.App.Constants;
    using Employees.App.Controllers.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class SetAddressCommand : Command
    {
        public SetAddressCommand(IEmployeesController employeesController)
            : base(employeesController)
        {
        }

        public override string Execute(IList<string> arguments)
        {
            var employeeId = int.Parse(arguments[0]);
            var address = string.Join(" ", arguments.Skip(1));

            this.EmployeesController.SetAddress(employeeId, address);

            return Messages.SuccessfullAddAddress;
        }
    }
}