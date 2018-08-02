namespace CarDealer.Data.ModelConfig
{
    using CarDealer.Models.DomainModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(s => s.Discount)
                   .HasDefaultValueSql("0");

            builder.HasOne(s => s.Car)
                   .WithMany(c => c.Sales)
                   .HasForeignKey(s => s.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Customer)
                   .WithMany(c => c.Boughts)
                   .HasForeignKey(s => s.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
