using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileConfig : IEntityTypeConfiguration<Mobile>
{

    public void Configure(EntityTypeBuilder<Mobile> builder)
    {
        builder.ToTable(nameof(Mobile));
        builder.HasMany(e => e.PairMaps).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.SubSerialMaps).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.PilotMaps).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.Cuspas).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.Supports).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
        builder.HasMany(e => e.CoUnits).WithOne(e => e.Mobile).HasForeignKey(e => e.MobileId).IsRequired(false);
    }

}
