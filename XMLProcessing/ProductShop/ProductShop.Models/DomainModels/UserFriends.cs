namespace ProductShop.Models.DomainModels
{
    public class UserFriends
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int FriendId { get; set; }
        public virtual User Friend { get; set; }
    }
}