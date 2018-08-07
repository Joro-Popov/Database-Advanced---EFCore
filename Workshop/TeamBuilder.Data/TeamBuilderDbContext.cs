namespace TeamBuilder.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeamBuilder.Data.ModelConfigurations;
    using TeamBuilder.Models;

    public class TeamBuilderDbContext : DbContext
    {
        public TeamBuilderDbContext()
        {
        }

        public TeamBuilderDbContext(DbContextOptions<TeamBuilderDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<TeamEvent> EventTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(Configuration.CONNECTION_STRING);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig());
            modelBuilder.ApplyConfiguration(new EventTeamConfig());
            modelBuilder.ApplyConfiguration(new InvitationConfig());
            modelBuilder.ApplyConfiguration(new TeamConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserTeamConfig());
        }
    }
}