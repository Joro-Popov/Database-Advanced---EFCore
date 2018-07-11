namespace P01_StudentSystem.Data.EntityConfiguration
{
    using P01_StudentSystem.Data.Models;

    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(e => e.StudentId);

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(p => p.PhoneNumber)
                   .HasColumnType("char(10)")
                   .IsRequired(false)
                   .IsUnicode(false);

            builder.Property(p => p.RegisteredOn)
                   .HasColumnType("DATETIME2");

            builder.Property(p => p.Birthday)
                   .IsRequired(false);
        }
    }
}