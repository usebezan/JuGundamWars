using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class PilotAbilityTypeConfiguration : IEntityTypeConfiguration<PilotAbility>
    {

        public void Configure(EntityTypeBuilder<PilotAbility> builder)
        {
            builder.ToTable(nameof(PilotAbility));
        }

    }

}
