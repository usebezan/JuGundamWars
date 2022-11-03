using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class MobileSuitPairTypeConfiguration : IEntityTypeConfiguration<MobileSuitPair>
    {

        public void Configure(EntityTypeBuilder<MobileSuitPair> builder)
        {
            builder.ToTable(nameof(MobileSuitPair));
        }

    }

}
