namespace SoftJail.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class MailConfig : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasOne(m => m.Prisoner)
                   .WithMany(p => p.Mails)
                   .HasForeignKey(m => m.PrisonerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
