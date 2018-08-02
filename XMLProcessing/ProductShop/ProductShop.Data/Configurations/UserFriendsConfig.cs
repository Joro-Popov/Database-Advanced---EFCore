using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductShop.Models.DomainModels;

namespace ProductShop.Data.Configurations
{
    public class UserFriendsConfig : IEntityTypeConfiguration<UserFriends>
    {
        public void Configure(EntityTypeBuilder<UserFriends> builder)
        {
            builder.HasKey(e => new { e.UserId, e.FriendId });

            builder.HasOne(u => u.User)
                   .WithMany(u => u.UserFriends)
                   .HasForeignKey(u => u.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}