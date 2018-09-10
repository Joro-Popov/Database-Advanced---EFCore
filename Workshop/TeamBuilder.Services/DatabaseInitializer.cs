namespace TeamBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;
    using TeamBuilder.Data;
    using TeamBuilder.Services.Contracts;

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly TeamBuilderDbContext context;

        public DatabaseInitializer(TeamBuilderDbContext context)
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