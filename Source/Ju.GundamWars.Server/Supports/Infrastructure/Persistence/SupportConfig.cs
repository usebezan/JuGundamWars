using Ju.GundamWars.Server.Supports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportConfig : IEntityTypeConfiguration<SupportEntity>
{
    public void Configure(EntityTypeBuilder<SupportEntity> builder)
    {
        builder.ToTable("Support");
        builder.HasMany(e => e.SupportLimitedSerialLinks).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.SupportSlotBadges).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.TagLinks).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }
}
