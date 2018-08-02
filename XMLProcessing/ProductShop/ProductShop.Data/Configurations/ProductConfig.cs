namespace ProductShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models.DomainModels;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Buyer)
                   .WithMany(p => p.ProductsBought)
                   .HasForeignKey(p => p.BuyerId);

            builder.HasOne(p => p.Seller)
                   .WithMany(p => p.ProductsSold)
                   .HasForeignKey(p => p.SellerId);
        }
    }
}