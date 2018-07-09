namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.PatientId);

            builder.Property(e => e.FirstName)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(e => e.LastName)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.Property(e => e.Address)
                   .HasMaxLength(250)
                   .IsUnicode();

            builder.Property(e => e.Email)
                   .HasMaxLength(80)
                   .IsUnicode(false);

            builder.HasMany(e => e.Prescriptions)
                   .WithOne(e => e.Patient)
                   .HasForeignKey(e => e.PatientId);

            builder.HasMany(e => e.Diagnoses)
                   .WithOne(e => e.Patient)
                   .HasForeignKey(e => e.PatientId);

            builder.HasMany(e => e.Visitations)
                   .WithOne(e => e.Patient)
                   .HasForeignKey(e => e.PatientId);
        }
    }
}