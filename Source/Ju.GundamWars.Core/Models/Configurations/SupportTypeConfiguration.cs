using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class SupportTypeConfiguration : IEntityTypeConfiguration<Support>
    {

        public void Configure(EntityTypeBuilder<Support> builder)
        {
            builder.ToTable(nameof(Support));

            // one to many, manually left join
            builder.HasOne(e => e.Serial).WithMany().HasForeignKey(e => e.SerialId).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial1).WithMany().HasForeignKey(e => e.LimitedSerial1Id).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial2).WithMany().HasForeignKey(e => e.LimitedSerial2Id).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial3).WithMany().HasForeignKey(e => e.LimitedSerial3Id).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial4).WithMany().HasForeignKey(e => e.LimitedSerial4Id).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial5).WithMany().HasForeignKey(e => e.LimitedSerial5Id).IsRequired(false);
            builder.HasOne(e => e.LimitedSerial6).WithMany().HasForeignKey(e => e.LimitedSerial6Id).IsRequired(false);
            builder.HasOne(e => e.Slot1).WithMany().HasForeignKey(e => e.Slot1Id).IsRequired(false);
            builder.HasOne(e => e.Badge1).WithMany().HasForeignKey(e => e.Badge1Id).IsRequired(false);
            builder.HasOne(e => e.Slot2).WithMany().HasForeignKey(e => e.Slot2Id).IsRequired(false);
            builder.HasOne(e => e.Badge2).WithMany().HasForeignKey(e => e.Badge2Id).IsRequired(false);
            builder.HasOne(e => e.Slot3).WithMany().HasForeignKey(e => e.Slot3Id).IsRequired(false);
            builder.HasOne(e => e.Badge3).WithMany().HasForeignKey(e => e.Badge3Id).IsRequired(false);
            builder.HasOne(e => e.Slot4).WithMany().HasForeignKey(e => e.Slot4Id).IsRequired(false);
            builder.HasOne(e => e.Badge4).WithMany().HasForeignKey(e => e.Badge4Id).IsRequired(false);
            builder.HasOne(e => e.Slot5).WithMany().HasForeignKey(e => e.Slot5Id).IsRequired(false);
            builder.HasOne(e => e.Badge5).WithMany().HasForeignKey(e => e.Badge5Id).IsRequired(false);
            builder.HasOne(e => e.Slot6).WithMany().HasForeignKey(e => e.Slot6Id).IsRequired(false);
            builder.HasOne(e => e.Badge6).WithMany().HasForeignKey(e => e.Badge6Id).IsRequired(false);
            builder.HasOne(e => e.Slot7).WithMany().HasForeignKey(e => e.Slot7Id).IsRequired(false);
            builder.HasOne(e => e.Badge7).WithMany().HasForeignKey(e => e.Badge7Id).IsRequired(false);
            builder.HasOne(e => e.Slot8).WithMany().HasForeignKey(e => e.Slot8Id).IsRequired(false);
            builder.HasOne(e => e.Badge8).WithMany().HasForeignKey(e => e.Badge8Id).IsRequired(false);
            builder.HasOne(e => e.Slot9).WithMany().HasForeignKey(e => e.Slot9Id).IsRequired(false);
            builder.HasOne(e => e.Badge9).WithMany().HasForeignKey(e => e.Badge9Id).IsRequired(false);
            builder.HasOne(e => e.Slot10).WithMany().HasForeignKey(e => e.Slot10Id).IsRequired(false);
            builder.HasOne(e => e.Badge10).WithMany().HasForeignKey(e => e.Badge10Id).IsRequired(false);
            builder.HasOne(e => e.Slot11).WithMany().HasForeignKey(e => e.Slot11Id).IsRequired(false);
            builder.HasOne(e => e.Badge11).WithMany().HasForeignKey(e => e.Badge11Id).IsRequired(false);
            builder.HasOne(e => e.Slot12).WithMany().HasForeignKey(e => e.Slot12Id).IsRequired(false);
            builder.HasOne(e => e.Badge12).WithMany().HasForeignKey(e => e.Badge12Id).IsRequired(false);
        }

    }

}
