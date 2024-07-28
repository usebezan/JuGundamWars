using Ju.GundamWars.Server.Supports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportSlotBadgeConfig : IEntityTypeConfiguration<SupportSlotBadgeEntity>
{
    public void Configure(EntityTypeBuilder<SupportSlotBadgeEntity> builder)
    {
        builder.ToTable("SupportSlotBadge");
        builder.HasKey(e => new { e.SupportId, e.Seq, });
    }
}
