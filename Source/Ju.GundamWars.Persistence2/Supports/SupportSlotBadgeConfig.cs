using Ju.GundamWars.Domain.Supports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Supports;

public class SupportSlotBadgeConfig : IEntityTypeConfiguration<SupportSlotBadge>
{

    public void Configure(EntityTypeBuilder<SupportSlotBadge> builder)
    {
        builder.ToTable(nameof(SupportSlotBadge));
        builder.HasKey(e => new { e.SupportId, e.Seq, });
    }

}
