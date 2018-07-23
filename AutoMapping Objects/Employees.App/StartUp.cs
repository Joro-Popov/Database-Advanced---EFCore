namespace Employees.App
{
    using AutoMapper;
    using Employees.App.Controllers;
    using Employees.App.Controllers.Contracts;
    using Employees.App.Core;
    using Employees.App.Core.Contracts;
    using Employees.App.Mappings;
    using Employees.Data;
    using Employees.Services;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureService();
            var engine = new Engine(service);

            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesDbContext>(opt => opt.UseSqlServer(Configuration.CONNECTION_STRING));

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<IEmployeesController, EmployeesController>();
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<EmployeeProfile>());
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}