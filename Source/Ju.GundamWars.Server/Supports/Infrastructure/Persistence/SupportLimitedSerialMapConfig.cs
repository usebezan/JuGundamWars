using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportLimitedSerialMapConfig : IEntityTypeConfiguration<SupportLimitedSerialMapDto>
{
    public void Configure(EntityTypeBuilder<SupportLimitedSerialMapDto> builder)
    {
        builder.ToTable("SupportLimitedSerialMap");
        builder.HasKey(e => new { e.SupportId, e.SerialId, });
    }
}
