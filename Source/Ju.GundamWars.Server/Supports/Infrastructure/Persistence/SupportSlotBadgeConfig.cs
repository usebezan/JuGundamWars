using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportSlotBadgeConfig : IEntityTypeConfiguration<SupportSlotBadgeDto>
{
    public void Configure(EntityTypeBuilder<SupportSlotBadgeDto> builder)
    {
        builder.ToTable("SupportSlotBadge");
        builder.HasKey(e => new { e.SupportId, e.Seq, });
    }
}
