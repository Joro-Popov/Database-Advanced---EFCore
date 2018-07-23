namespace Employees.App.Core
{
    using Employees.App.Commands.Contracts;
    using Employees.App.Constants;
    using Employees.App.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandParser : ICommandParser
    {
        private const string SUFFIX = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandParser(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string ProcessCommand(IList<string> arguments)
        {
            var commandName = arguments[0] + SUFFIX;
            var args = arguments.Skip(1).ToList();

            var commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(a => a.Name == commandName);

            if (commandType == null)
            {
                throw new ArgumentNullException("command", string.Format(ErrorMessages.CommandDoesNotExists));
            }

            var constructor = commandType.GetConstructors().First();

            var ctorParams = constructor.GetParameters().Select(s => s.ParameterType);

            var service = ctorParams.Select(this.serviceProvider.GetService).ToArray();

            var command = (ICommand)constructor.Invoke(service);

            return command.Execute(args);
        }
    }
}