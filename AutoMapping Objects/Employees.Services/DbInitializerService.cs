namespace Employees.Services
{
    using Employees.Data;
    using Employees.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly EmployeesDbContext context;

        public DbInitializerService(EmployeesDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                context.Database.Migrate();
            }
        }
    }
}