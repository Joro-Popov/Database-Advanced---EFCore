namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeamBuilder.Models.Enums;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Username { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [MinLength(6)]
        [MaxLength(30)]
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Invitation> ReceivedInvitations { get; set; } = new List<Invitation>();

        public virtual ICollection<Team> CreatedTeams { get; set; } = new List<Team>();

        public virtual ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public virtual ICollection<Event> CreatedEvents { get; set; } = new List<Event>();
    }
}