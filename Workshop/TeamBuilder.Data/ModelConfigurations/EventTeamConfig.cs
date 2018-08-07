namespace TeamBuilder.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class EventTeamConfig : IEntityTypeConfiguration<TeamEvent>
    {
        public void Configure(EntityTypeBuilder<TeamEvent> builder)
        {
            builder.HasKey(te => new { te.EventId, te.TeamId });

            builder.HasOne(te => te.Event)
                   .WithMany(e => e.ParticipatingEventTeams)
                   .HasForeignKey(te => te.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(te => te.Team)
                   .WithMany(t => t.Events)
                   .HasForeignKey(te => te.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}