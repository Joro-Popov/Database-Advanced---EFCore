namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class OrderItemsConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => new { oi.ItemId, oi.OrderId });

            builder.HasOne(oi => oi.Item)
                   .WithMany(i => i.OrderItems)
                   .HasForeignKey(oi => oi.ItemId);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId);
            
        }
    }
}
