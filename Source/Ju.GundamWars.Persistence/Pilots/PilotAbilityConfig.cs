using Ju.GundamWars.Pilots.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Pilots;

public class PilotAbilityConfig : IEntityTypeConfiguration<PilotAbility>
{

    public void Configure(EntityTypeBuilder<PilotAbility> builder)
    {
        builder.ToTable(nameof(PilotAbility));
        builder.Ignore(e => e.Name);
        builder.Ignore(e => e.BoostText);
        builder.Ignore(e => e.BoostTarget);
    }

}
