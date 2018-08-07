namespace TeamBuilder.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(t => t.Acronym)
                .HasColumnType("CHAR(3)");

            builder.HasOne(t => t.Creator)
                   .WithMany(u => u.CreatedTeams)
                   .HasForeignKey(t => t.CreatorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}