namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasOne(g => g.HomeTeam)
                   .WithMany(t => t.HomeGames)
                   .HasForeignKey(g => g.HomeTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(g => g.AwayTeam)
                   .WithMany(t => t.AwayGames)
                   .HasForeignKey(g => g.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(g => g.HomeTeamGoals)
                   .HasDefaultValue(0);

            builder.Property(g => g.AwayTeamGoals)
                   .HasDefaultValue(0);

            builder.Property(g => g.DateTime)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(g => g.HomeTeamBetRate)
                   .HasDefaultValue(0);

            builder.Property(g => g.AwayTeamBetRate)
                   .HasDefaultValue(0);

            builder.Property(g => g.DrawBetRate)
                   .HasDefaultValue(0);

            builder.Property(g => g.Result)
                   .IsRequired()
                   .IsUnicode(false)
                   .HasMaxLength(10);
        }
    }
}