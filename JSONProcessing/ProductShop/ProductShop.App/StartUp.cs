namespace ProductShop.App
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using ProductShop.App.Core;
    using ProductShop.App.Core.Contracts;
    using ProductShop.App.Mappings;
    using ProductShop.Data;
    using ProductShop.Services;
    using ProductShop.Services.Contracts;
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

            serviceCollection.AddDbContext<ProductShopDbContext>(options =>
                   options.UseLazyLoadingProxies().UseSqlServer(Configuration.CONNECTION_STRING));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<ProductShopProfile>());
            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IProductService, ProductService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}