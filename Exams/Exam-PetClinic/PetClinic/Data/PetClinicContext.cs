namespace PetClinic.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetClinic.Data.ModelConfigurations;
    using PetClinic.Models;

    public class PetClinicContext : DbContext
    {
        public PetClinicContext()
        {
        }

        public PetClinicContext(DbContextOptions options)  :base(options)
        {
        }

        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<AnimalAid> AnimalAids { get; set; }
        public DbSet<ProcedureAnimalAid> ProceduresAnimalAids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AnimalConfig());
            builder.ApplyConfiguration(new PassportConfig());
            builder.ApplyConfiguration(new ProcedureAnimalAidConfig());
            builder.ApplyConfiguration(new ProcedureConfig());
        }
    }
}
