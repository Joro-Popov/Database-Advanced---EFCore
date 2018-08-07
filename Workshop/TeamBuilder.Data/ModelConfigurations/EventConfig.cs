namespace TeamBuilder.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(e => e.Creator)
                   .WithMany(c => c.CreatedEvents)
                   .HasForeignKey(e => e.CreatorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}