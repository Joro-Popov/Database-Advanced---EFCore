namespace Instagraph.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Username { get; set; }

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        public int ProfilePictureId { get; set; }

        [Required]
        public virtual Picture ProfilePicture { get; set; }

        public virtual ICollection<UserFollower> Followers { get; set; } = new List<UserFollower>();

        public virtual ICollection<UserFollower> UsersFollowing { get; set; } = new List<UserFollower>();

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
