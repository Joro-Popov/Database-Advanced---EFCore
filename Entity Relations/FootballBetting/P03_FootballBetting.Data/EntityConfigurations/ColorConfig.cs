namespace P03_FootballBetting.Data.EntityConfigurations
{
    using P03_FootballBetting.Data.Models;

    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(c => c.Name)
                   .IsRequired()
                   .IsUnicode(false)
                   .HasMaxLength(50);
        }
    }
}