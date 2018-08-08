namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Employee)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(o => o.EmployeeId);
        }
    }
}
