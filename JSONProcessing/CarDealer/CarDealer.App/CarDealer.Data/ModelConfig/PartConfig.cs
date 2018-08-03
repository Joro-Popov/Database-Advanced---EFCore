namespace CarDealer.Data.ModelConfig
{
    using CarDealer.Models.DomainModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartConfig : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasOne(p => p.Supplier)
                   .WithMany(s => s.Parts)
                   .HasForeignKey(p => p.SupplierId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}