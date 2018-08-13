namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.ModelConfigurations;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Department> Departments { get; set; }

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
            builder.ApplyConfiguration(new CellConfig());
            builder.ApplyConfiguration(new MailConfig());
            builder.ApplyConfiguration(new OfficerConfig());
            builder.ApplyConfiguration(new OfficerPrisonerConfig());
            builder.ApplyConfiguration(new PrisonerConfig());
        }
	}
}