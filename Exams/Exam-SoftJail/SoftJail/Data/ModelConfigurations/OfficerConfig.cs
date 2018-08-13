namespace SoftJail.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;

    public class OfficerConfig : IEntityTypeConfiguration<Officer>
    {
        public void Configure(EntityTypeBuilder<Officer> builder)
        {
            builder.HasOne(o => o.Department)
                   .WithMany(d => d.Officers)
                   .HasForeignKey(o => o.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
