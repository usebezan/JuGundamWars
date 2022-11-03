using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class SupportBadgeTypeConfiguration : IEntityTypeConfiguration<SupportBadge>
    {

        public void Configure(EntityTypeBuilder<SupportBadge> builder)
        {
            builder.ToTable(nameof(SupportBadge));
        }

    }

}
