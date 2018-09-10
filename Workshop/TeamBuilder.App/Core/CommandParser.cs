using System;
using System.Linq;
using System.Reflection;
using TeamBuilder.App.Core.Contracts;
using TeamBuilder.App.Utilities;

namespace TeamBuilder.App.Core
{
    public class CommandParser : ICommandParser
    {
        private const string SUFFIX = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandParser(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string ParseCommand(string commandDetails)
        {
            var details = commandDetails.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);

            var inputCommand = details[0] + SUFFIX;

            var arguments = details.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(x => x.Name == inputCommand);

            if (commandType == null)
            {
                throw new NotSupportedException(string.Format(ErrorMessages.INVALID_COMMAND, details[0]));
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor.GetParameters()
                                        .Select(x => x.ParameterType)
                                        .ToArray();

            var services = constructorParameters.Select(serviceProvider.GetService).ToArray();

            var specificCommand = (ICommand)constructor.Invoke(services);

            var commandExecutionMessage = specificCommand.Execute(arguments);

            return commandExecutionMessage;
        }
    }
}