using Ju.GundamWars.Supports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Supports;

public class SupportConfig : IEntityTypeConfiguration<Support>
{

    public void Configure(EntityTypeBuilder<Support> builder)
    {
        builder.ToTable(nameof(Support));
        builder.HasMany(e => e.LimitedSerialMaps).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
        builder.HasMany(e => e.SlotBadges).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
    }

}
