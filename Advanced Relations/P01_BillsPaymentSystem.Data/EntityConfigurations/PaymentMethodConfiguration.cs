namespace P01_BillsPaymentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasOne(pm => pm.User)
                   .WithMany(u => u.PaymentMethods)
                   .HasForeignKey(pm => pm.UserId);

            builder.HasOne(pm => pm.CreditCard)
                   .WithOne(c => c.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(pm => pm.CreditCardId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pm => pm.BankAccount)
                   .WithOne(b => b.PaymentMethod)
                   .HasForeignKey<PaymentMethod>(b => b.BankAccountId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(pm => new
            {
                pm.UserId,
                pm.BankAccountId,
                pm.CreditCardId
            })
            .IsUnique();
        }
    }
}