namespace Instagraph.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int PostId { get; set; }

        [Required]
        public virtual Post Post { get; set; }
    }
}
