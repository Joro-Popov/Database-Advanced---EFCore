namespace TeamBuilder.App.Core
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.Services.Contracts;

    public class Engine : IEngine
    {
        private const string TERMINATING_COMMAND = "Exit";

        private readonly IServiceProvider serviceProvider;
        private readonly ICommandParser commandParser;
        private readonly IDatabaseInitializer dbInitializer;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.commandParser = this.serviceProvider.GetService<ICommandParser>();
            this.dbInitializer = this.serviceProvider.GetService<IDatabaseInitializer>();
        }

        public void Run()
        {
            this.dbInitializer.InitializeDatabase();

            while (true)
            {
                try
                {
                    Console.Write("Enter Command: ");
                    var command = Console.ReadLine();

                    var commandExecutionMessage = this.commandParser.ParseCommand(command);

                    Console.WriteLine(commandExecutionMessage);

                    if (command == TERMINATING_COMMAND)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException().Message);
                }
            }
        }
    }
}