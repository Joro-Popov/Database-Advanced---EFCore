namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.MedicamentId);

            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.HasMany(e => e.Prescriptions)
                   .WithOne(e => e.Medicament)
                   .HasForeignKey(e => e.MedicamentId);
        }
    }
}