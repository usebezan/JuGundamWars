using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class SerialTypeConfiguration : IEntityTypeConfiguration<Serial>
    {

        public void Configure(EntityTypeBuilder<Serial> builder)
        {
            builder.ToTable(nameof(Serial));
        }

    }

}
