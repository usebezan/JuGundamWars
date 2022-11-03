using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class PilotSkillTypeConfiguration : IEntityTypeConfiguration<PilotSkill>
    {

        public void Configure(EntityTypeBuilder<PilotSkill> builder)
        {
            builder.ToTable(nameof(PilotSkill));
        }

    }

}
