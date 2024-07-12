using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportConfig : IEntityTypeConfiguration<SupportDto>
{
    public void Configure(EntityTypeBuilder<SupportDto> builder)
    {
        builder.ToTable("Support");
        builder.HasMany(e => e.LimitedSerialMaps).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
        builder.HasMany(e => e.SlotBadges).WithOne(e => e.Support).HasForeignKey(e => e.SupportId).IsRequired(false);
    }
}
