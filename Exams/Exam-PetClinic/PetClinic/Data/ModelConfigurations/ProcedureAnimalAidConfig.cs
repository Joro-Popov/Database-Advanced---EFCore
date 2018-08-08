namespace PetClinic.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;
    using System;

    public class ProcedureAnimalAidConfig : IEntityTypeConfiguration<ProcedureAnimalAid>
    {
        public void Configure(EntityTypeBuilder<ProcedureAnimalAid> builder)
        {
            builder.HasKey(p => new { p.AnimalAidId, p.ProcedureId });

            builder.HasOne(p => p.AnimalAid)
                   .WithMany(a => a.AnimalAidProcedures)
                   .HasForeignKey(p => p.AnimalAidId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Procedure)
                   .WithMany(p => p.ProcedureAnimalAids)
                   .HasForeignKey(p => p.ProcedureId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
