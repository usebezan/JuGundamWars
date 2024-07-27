using Ju.GundamWars.Server.Pilots.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotSlotAbilityConfig : IEntityTypeConfiguration<PilotSlotAbilityEntity>
{
    public void Configure(EntityTypeBuilder<PilotSlotAbilityEntity> builder)
    {
        builder.ToTable("PilotSlotAbility");
        builder.HasKey(e => new { e.PilotId, e.Seq, });
    }
}
