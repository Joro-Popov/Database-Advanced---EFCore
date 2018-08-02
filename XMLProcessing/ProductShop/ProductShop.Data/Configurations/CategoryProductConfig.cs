namespace ProductShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ProductShop.Models.DomainModels;

    public class CategoryProductConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(cp => new { cp.CategoryId, cp.ProductId });

            builder.HasOne(cp => cp.Category)
                   .WithMany(cp => cp.Products)
                   .HasForeignKey(cp => cp.CategoryId);

            builder.HasOne(cp => cp.Product)
                   .WithMany(p => p.Categories)
                   .HasForeignKey(cp => cp.ProductId);
        }
    }
}