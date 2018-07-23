namespace Employees.Data
{
    using Employees.Data.EntityConfigurations;
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext()
        {
        }

        public EmployeesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(Configuration.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}