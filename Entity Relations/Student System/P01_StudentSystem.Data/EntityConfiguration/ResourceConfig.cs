namespace P01_StudentSystem.Data.EntityConfiguration
{
    using P01_StudentSystem.Data.Models;

    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(e => e.ResourceId);

            builder.Property(e => e.Name)
                   .HasMaxLength(50)
                   .IsUnicode()
                   .IsRequired();

            builder.Property(e => e.Url)
                   .IsUnicode(false);

            builder.HasOne(e => e.Course)
                   .WithMany(c => c.Resources)
                   .HasForeignKey(e => e.CourseId);
        }
    }
}