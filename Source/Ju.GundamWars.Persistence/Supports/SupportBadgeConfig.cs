using Ju.GundamWars.Supports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Supports;

public class SupportBadgeConfig : IEntityTypeConfiguration<SupportBadge>
{

    public void Configure(EntityTypeBuilder<SupportBadge> builder)
    {
        builder.ToTable(nameof(SupportBadge));
        builder.Ignore(e => e.Name);
        builder.Ignore(e => e.BoostText);
        builder.Ignore(e => e.BoostTarget);
    }

}
