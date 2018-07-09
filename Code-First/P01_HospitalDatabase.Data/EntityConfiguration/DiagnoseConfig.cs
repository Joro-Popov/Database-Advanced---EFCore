namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(e => e.DiagnoseId);

            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(e => e.Comments)
                   .HasMaxLength(250)
                   .IsUnicode();
        }
    }
}