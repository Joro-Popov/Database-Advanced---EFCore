namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(p => p.Name)
                   .IsRequired()
                   .IsUnicode(false)
                   .HasMaxLength(50);

            builder.Property(p => p.SquadNumber)
                   .IsRequired();

            builder.Property(p => p.IsInjured)
                   .HasDefaultValue(false);

            builder.HasOne(p => p.Team)
                   .WithMany(t => t.Players)
                   .HasForeignKey(p => p.TeamId);

            builder.HasOne(p => p.Position)
                   .WithMany(p => p.Players)
                   .HasForeignKey(p => p.PositionId);
        }
    }
}