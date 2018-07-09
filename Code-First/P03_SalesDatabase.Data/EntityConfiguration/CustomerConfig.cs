namespace P03_SalesDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_SalesDatabase.Data.Models;

    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasMaxLength(80)
                   .IsUnicode(false);

            builder.Property(e => e.CreditCardNumber)
                   .IsUnicode(false)
                   .IsRequired();

            builder.HasMany(e => e.Sales)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
        }
    }
}