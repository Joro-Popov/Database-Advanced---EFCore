﻿namespace TeamBuilder.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class UserTeamConfig : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(ut => new { ut.TeamId, ut.UserId });

            builder.HasOne(ut => ut.Team)
                   .WithMany(t => t.UserTeams)
                   .HasForeignKey(ut => ut.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ut => ut.User)
                   .WithMany(u => u.UserTeams)
                   .HasForeignKey(ut => ut.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}