namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsRequired()
                   .IsUnicode(false);

            builder.Property(e => e.Initials)
                   .IsRequired()
                   .HasColumnType("CHAR(3)");

            builder.Property(e => e.Budget)
                   .HasDefaultValue(0);

            builder.HasOne(t => t.PrimaryKitColor)
                   .WithMany(c => c.PrimaryKitTeams)
                   .HasForeignKey(t => t.PrimaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.SecondaryKitColor)
                   .WithMany(c => c.SecondaryKitTeams)
                   .HasForeignKey(t => t.SecondaryKitColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Town)
                   .WithMany(t => t.Teams)
                   .HasForeignKey(e => e.TownId);
        }
    }
}