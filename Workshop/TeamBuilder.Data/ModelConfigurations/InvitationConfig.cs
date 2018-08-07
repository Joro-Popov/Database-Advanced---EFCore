namespace TeamBuilder.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class InvitationConfig : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.Property(i => i.IsActive)
                .HasDefaultValueSql("1");

            builder.HasOne(i => i.Team)
                   .WithMany(t => t.Invitations)
                   .HasForeignKey(i => i.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.InvitedUser)
                   .WithMany(u => u.ReceivedInvitations)
                   .HasForeignKey(i => i.InvitedUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}