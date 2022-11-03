using Ju.GundamWars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Ju.GundamWars.Models.Configurations
{

    public class UnitSAbilityTypeConfiguration : IEntityTypeConfiguration<UnitSAbility>
    {

        public void Configure(EntityTypeBuilder<UnitSAbility> builder)
        {
            builder.ToTable(nameof(UnitSAbility));
        }

    }

}
