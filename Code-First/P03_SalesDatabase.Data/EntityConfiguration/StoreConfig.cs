namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(e => e.StoreId);

            builder.Property(e => e.Name)
                   .HasMaxLength(80)
                   .IsRequired()
                   .IsUnicode();

            builder.HasMany(e => e.Sales)
                   .WithOne(e => e.Store)
                   .HasForeignKey(e => e.StoreId);
        }
    }
}