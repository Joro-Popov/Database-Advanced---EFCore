namespace Instagraph.Data.ModelConfigurations
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserFollowerCofig : IEntityTypeConfiguration<UserFollower>
    {
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(uf => new { uf.UserId, uf.FollowerId });

            builder.HasOne(uf => uf.User)
                   .WithMany(uf => uf.Followers)
                   .HasForeignKey(uf => uf.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
