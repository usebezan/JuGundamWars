using Ju.GundamWars.Pilots.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Pilots;

public class PilotSkillConfig : IEntityTypeConfiguration<PilotSkill>
{

    public void Configure(EntityTypeBuilder<PilotSkill> builder)
    {
        builder.ToTable(nameof(PilotSkill));
    }

}
