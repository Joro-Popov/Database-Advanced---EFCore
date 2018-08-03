namespace CarDealer.App.Core
{
    using CarDealer.App.Core.Contracts;
    using CarDealer.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;

    public class Engine : IEngine
    {
        private const string TERMINATING_COMMAND = "Exit";

        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeService = this.serviceProvider.GetService<IDatabaseInitializerService>();
            initializeService.InitializeDatabase();

            var commandParser = this.serviceProvider.GetService<ICommandParser>();

            var allowedCommands = new List<string>()
            {
                "ExportOrderedCustomers",
                "ExportCarsFromMakeToyota",
                "ExportLocalSuppliers",
                "ExportCarsWithTheirListOfParts",
                "ExportTotalSalesByCustomer",
                "ExportSalesWithAppliedDiscount"
            };

            Console.WriteLine("Please enter one of the following commands: \r\n");
            Console.WriteLine(string.Join(Environment.NewLine + "\r\n", allowedCommands));
            Console.WriteLine();

            while (true)
            {
                var inputCommand = Console.ReadLine();

                string result = commandParser.ParseCommand(inputCommand);

                Console.WriteLine(result);

                if (inputCommand == TERMINATING_COMMAND)
                {
                    return;
                }
            }
        }
    }
}