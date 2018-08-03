namespace CarDealer.Data.ModelConfig
{
    using CarDealer.Models.DomainModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartCarsConfig : IEntityTypeConfiguration<PartCars>
    {
        public void Configure(EntityTypeBuilder<PartCars> builder)
        {
            builder.HasKey(pc => new { pc.PartId, pc.CarId });

            builder.HasOne(pc => pc.Part)
                   .WithMany(p => p.Cars)
                   .HasForeignKey(pc => pc.PartId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pc => pc.Car)
                   .WithMany(c => c.Parts)
                   .HasForeignKey(pc => pc.CarId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}