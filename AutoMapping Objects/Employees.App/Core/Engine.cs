namespace Employees.App.Core
{
    using Employees.App.Core.Contracts;
    using Employees.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeDb = this.serviceProvider.GetService<IDbInitializerService>();
            initializeDb.InitializeDatabase();

            var commandParser = this.serviceProvider.GetService<ICommandParser>();

            while (true)
            {
                Console.Write("Enter command: ");

                var arguments = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                try
                {
                    var commandName = arguments[0];

                    var result = commandParser.ProcessCommand(arguments);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}