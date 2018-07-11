namespace P03_FootballBetting.Data.EntityConfigurations
{
    using P03_FootballBetting.Data.Models;

    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.Property(b => b.Amount)
                   .HasDefaultValue(0);

            builder.Property(b => b.Prediction)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(20);

            builder.Property(b => b.DateTime)
                   .HasDefaultValueSql("GETDATE()");

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Bets)
                   .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Game)
                   .WithMany(u => u.Bets)
                   .HasForeignKey(b => b.GameId);
        }
    }
}