namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.DoctorId);

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.HasMany(e => e.Visitations)
                   .WithOne(e => e.Doctor)
                   .HasForeignKey(e => e.DoctorId);
        }
    }
}