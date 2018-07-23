using System.Collections.Generic;

namespace Employees.App.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> arguments);
    }
}