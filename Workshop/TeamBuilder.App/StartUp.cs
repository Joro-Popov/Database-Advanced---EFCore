namespace TeamBuilder.App
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using TeamBuilder.App.Core;
    using TeamBuilder.App.Core.Contracts;
    using TeamBuilder.Data;
    using TeamBuilder.Services;
    using TeamBuilder.Services.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            var services = ConfigureServices();
            var engine = new Engine(services);

            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<TeamBuilderDbContext>(options =>
                   options.UseLazyLoadingProxies().UseSqlServer(Configuration.CONNECTION_STRING));

            serviceCollection.AddTransient<ICommandParser, CommandParser>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IDatabaseInitializer, DatabaseInitializer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}