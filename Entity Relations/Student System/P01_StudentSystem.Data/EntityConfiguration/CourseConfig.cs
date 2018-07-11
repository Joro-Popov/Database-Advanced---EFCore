namespace P01_StudentSystem.Data.EntityConfiguration
{
    using P01_StudentSystem.Data.Models;

    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.CourseId);

            builder.Property(e => e.Name)
                   .HasMaxLength(80)
                   .IsUnicode();

            builder.Property(e => e.Description)
                   .IsUnicode()
                   .IsRequired(false);

            builder.Property(e => e.StartDate)
                   .HasColumnType("DATETIME2");

            builder.Property(e => e.EndDate)
                   .HasColumnType("DATETIME2");
        }
    }
}