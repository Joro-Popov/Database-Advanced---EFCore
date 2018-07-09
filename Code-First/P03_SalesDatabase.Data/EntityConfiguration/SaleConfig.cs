namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class SaleConfig : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.SaleId);

            builder.Property(e => e.Date)
                   .HasDefaultValueSql("GETDATE()")
                   .HasColumnType("DATETIME2")
                   .IsRequired();
        }
    }
}