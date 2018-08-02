namespace CarDealer.Data.ModelConfig
{
    using CarDealer.Models.DomainModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.TravelledDistance)
                   .HasDefaultValueSql("0");
        }
    }
}
