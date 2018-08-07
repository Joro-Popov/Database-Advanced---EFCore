namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Event
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<TeamEvent> ParticipatingEventTeams { get; set; } = new List<TeamEvent>();

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} {this.StartDate} {this.EndDate}");
            sb.AppendLine($"{Description}");
            sb.AppendLine("Teams:");

            foreach (var ev in ParticipatingEventTeams)
            {
                sb.AppendLine($"-{ev.Team.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}