using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Mobiles;

public class MobileSSkillConfig : IEntityTypeConfiguration<MobileSSkill>
{

    public void Configure(EntityTypeBuilder<MobileSSkill> builder)
    {
        builder.ToTable(nameof(MobileSSkill));
        builder.Ignore(e => e.GradeText);
        builder.Ignore(e => e.GradeColor);
    }

}
