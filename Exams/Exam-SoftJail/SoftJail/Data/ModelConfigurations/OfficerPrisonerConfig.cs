namespace SoftJail.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftJail.Data.Models;
    using System;

    public class OfficerPrisonerConfig : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> builder)
        {
            builder.HasKey(op => new { op.OfficerId, op.PrisonerId });

            builder.HasOne(op => op.Officer)
                   .WithMany(p => p.OfficerPrisoners)
                   .HasForeignKey(op => op.OfficerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(op => op.Prisoner)
                   .WithMany(p => p.PrisonerOfficers)
                   .HasForeignKey(op => op.PrisonerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
