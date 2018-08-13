namespace SoftJail.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class PrisonerConfig : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> builder)
        {
            builder.HasOne(p => p.Cell)
                   .WithMany(c => c.Prisoners)
                   .HasForeignKey(p => p.CellId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
