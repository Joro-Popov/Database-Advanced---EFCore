namespace Employees.App.Core.Contracts
{
    using System.Collections.Generic;

    public interface ICommandParser
    {
        string ProcessCommand(IList<string> arguments);
    }
}