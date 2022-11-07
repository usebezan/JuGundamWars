using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Version = Ju.GundamWars.Models.Entities.Version;


namespace Ju.GundamWars.Models.Configurations
{

    public class VersionTypeConfiguration : IEntityTypeConfiguration<Version>
    {

        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable(nameof(Version));
        }

    }

}
