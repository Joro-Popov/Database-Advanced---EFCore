namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.GameId });

            builder.HasOne(p => p.Game)
                   .WithMany(g => g.PlayerStatistics)
                   .HasForeignKey(p => p.GameId);

            builder.HasOne(p => p.Player)
                   .WithMany(p => p.PlayerStatistics)
                   .HasForeignKey(p => p.PlayerId);
        }
    }
}