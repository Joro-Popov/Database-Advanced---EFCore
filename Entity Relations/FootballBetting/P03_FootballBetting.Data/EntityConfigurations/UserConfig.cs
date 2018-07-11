namespace P03_FootballBetting.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(50);

            builder.Property(p => p.Password)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(100);

            builder.Property(p => p.Email)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(100);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .IsUnicode()
                   .HasMaxLength(50);

            builder.Property(p => p.Balance)
                   .HasDefaultValue(0);
        }
    }
}