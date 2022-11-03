using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class PilotTypeConfiguration : IEntityTypeConfiguration<Pilot>
    {

        public void Configure(EntityTypeBuilder<Pilot> builder)
        {
            builder.ToTable(nameof(Pilot));

            // one to many, manually left join
            builder.HasOne(e => e.Serial).WithMany().HasForeignKey(e => e.SerialId).IsRequired(false);
            builder.HasOne(e => e.Skill).WithMany().HasForeignKey(e => e.SkillId).IsRequired(false);
            builder.HasOne(e => e.Ability1).WithMany().HasForeignKey(e => e.Ability1Id).IsRequired(false);
            builder.HasOne(e => e.Ability2).WithMany().HasForeignKey(e => e.Ability2Id).IsRequired(false);
            builder.HasOne(e => e.Ability3).WithMany().HasForeignKey(e => e.Ability3Id).IsRequired(false);
        }

    }

}
