namespace TeamBuilder.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Team
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }

        [Required]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; } = new List<Invitation>();

        public virtual ICollection<UserTeam> UserTeams { get; set; } = new List<UserTeam>();

        public virtual ICollection<TeamEvent> Events { get; set; } = new List<TeamEvent>();

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} {this.Acronym}");
            sb.AppendLine("Members:");

            foreach (var team in this.UserTeams)
            {
                sb.AppendLine($"--{team.User.Username}");
            }

            return sb.ToString().Trim();
        }
    }
}