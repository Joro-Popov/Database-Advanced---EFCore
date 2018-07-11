namespace P01_StudentSystem.Data.EntityConfiguration
{
    using P01_StudentSystem.Data.Models;

    public class HomeworkConfig : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(e => e.HomeworkId);

            builder.Property(e => e.Content)
                   .IsUnicode(false);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.HomeworkSubmissions)
                   .HasForeignKey(e => e.CourseId);

            builder.HasOne(e => e.Student)
                   .WithMany(s => s.HomeworkSubmissions)
                   .HasForeignKey(e => e.StudentId);
        }
    }
}