using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class SupportSlotTypeConfiguration : IEntityTypeConfiguration<SupportSlot>
    {

        public void Configure(EntityTypeBuilder<SupportSlot> builder)
        {
            builder.ToTable(nameof(SupportSlot));
        }

    }

}
