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

        public string ParseCommand(string input)
        {
            var inputArgs = input.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);

            var inputCommand = inputArgs[0] + SUFFIX;

            var args = inputArgs.Skip(1).ToArray();

            var commandType = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(x => x.Name == inputCommand);

            if (commandType == null)
            {
                throw new NotSupportedException(string.Format(ErrorMessages.InvalidCommand, inputArgs[0]));
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor.GetParameters()
                                        .Select(x => x.ParameterType)
                                        .ToArray();

            var service = constructorParameters.Select(serviceProvider.GetService)
                                               .ToArray();

            var command = (ICommand)constructor.Invoke(service);

            var result = command.Execute(args);

            return result;
        }
    }
}