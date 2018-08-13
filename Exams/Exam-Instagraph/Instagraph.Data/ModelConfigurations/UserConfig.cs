namespace Instagraph.Data.ModelConfigurations
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Username).IsUnique();

            builder.HasOne(u => u.ProfilePicture)
                   .WithMany(p => p.Users)
                   .HasForeignKey(u => u.ProfilePictureId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
