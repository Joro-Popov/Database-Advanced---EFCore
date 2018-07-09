namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(e => e.Quantity)
                   .IsRequired()
                   .HasDefaultValueSql("0");

            builder.Property(e => e.Price)
                   .IsRequired()
                   .HasDefaultValueSql("0");

            builder.HasMany(e => e.Sales)
                   .WithOne(e => e.Product)
                   .HasForeignKey(e => e.ProductId);

            builder.Property(e => e.Description)
                   .HasMaxLength(250)
                   .IsUnicode(false)
                   .HasDefaultValue("No description");
        }
    }
}