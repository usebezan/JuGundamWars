using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class MobileSuitType1Configuration : IEntityTypeConfiguration<MobileSuit>
    {

        public void Configure(EntityTypeBuilder<MobileSuit> builder)
        {
            builder.ToTable(nameof(MobileSuit));

            // one to many, manually left join
            builder.HasOne(e => e.Serial).WithMany().HasForeignKey(e => e.SerialId).IsRequired(false);
            builder.HasOne(e => e.SubSerial1).WithMany().HasForeignKey(e => e.SubSerial1Id).IsRequired(false);
            builder.HasOne(e => e.SubSerial2).WithMany().HasForeignKey(e => e.SubSerial2Id).IsRequired(false);
            builder.HasOne(e => e.SubSerial3).WithMany().HasForeignKey(e => e.SubSerial3Id).IsRequired(false);
            builder.HasOne(e => e.SubSerial4).WithMany().HasForeignKey(e => e.SubSerial4Id).IsRequired(false);
            builder.HasOne(e => e.Pilot).WithMany().HasForeignKey(e => e.PilotId).IsRequired(false);
            builder.HasOne(e => e.SAbility1).WithMany().HasForeignKey(e => e.SAbility1Id).IsRequired(false);
            builder.HasOne(e => e.SAbility2).WithMany().HasForeignKey(e => e.SAbility2Id).IsRequired(false);
            builder.HasOne(e => e.SAbility3).WithMany().HasForeignKey(e => e.SAbility3Id).IsRequired(false);
            builder.HasOne(e => e.SAbility4).WithMany().HasForeignKey(e => e.SAbility4Id).IsRequired(false);

            // one to ont, manually left join
            builder.HasOne(e => e.Support1).WithOne().HasForeignKey<MobileSuit>(e => e.Support1Id).IsRequired(false);
            builder.HasOne(e => e.Support2).WithOne().HasForeignKey<MobileSuit>(e => e.Support2Id).IsRequired(false);
            builder.HasOne(e => e.Support3).WithOne().HasForeignKey<MobileSuit>(e => e.Support3Id).IsRequired(false);
            builder.HasOne(e => e.Support4).WithOne().HasForeignKey<MobileSuit>(e => e.Support4Id).IsRequired(false);
        }

    }

}
