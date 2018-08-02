namespace CarDealer.App.Core
{
    using CarDealer.App.Commands.Contracts;
    using CarDealer.App.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandParser : ICommandParser
    {
        private readonly IServiceProvider serviceProvider;

        public CommandParser(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string ParseCommand(string input)
        {
            var commandType = Assembly.GetCallingAssembly()
                               .GetTypes()
                               .FirstOrDefault(x => x.Name == input);

            if (commandType == null)
            {
                throw new InvalidOperationException();
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameters = constructor.GetParameters()
                                        .Select(x => x.ParameterType)
                                        .ToArray();

            var service = constructorParameters.Select(serviceProvider.GetService)
                                               .ToArray();

            var command = (ICommand)constructor.Invoke(service);

            var result = command.Execute();

            return result;
        }
    }
}
