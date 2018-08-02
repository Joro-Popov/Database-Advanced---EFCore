namespace CarDealer.App
{
    using AutoMapper;
    using CarDealer.App.Core;
    using CarDealer.App.Core.Contracts;
    using CarDealer.Data;
    using CarDealer.Services;
    using CarDealer.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var service = ConfigureServices();
            var engine = new Engine(service);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<CarDealerDbContext>(options =>
                   options.UseLazyLoadingProxies().UseSqlServer(Configuration.CONNECTION_STRING));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<CarDealerProfile>());
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<ICarService, CarService>();
            serviceCollection.AddTransient<ISupplierService, SupplierService>();
            serviceCollection.AddTransient<ICustomerService, CustomerService>();
            serviceCollection.AddTransient<ISaleService, SaleService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
