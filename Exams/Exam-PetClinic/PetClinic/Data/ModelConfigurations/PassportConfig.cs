namespace PetClinic.Data.ModelConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PetClinic.Models;
    using System;

    public class PassportConfig : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasOne(p => p.Animal)
                   .WithOne(a => a.Passport)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
