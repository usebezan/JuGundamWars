using Ju.GundamWars.Server.Supports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportLimitedSerialMapConfig : IEntityTypeConfiguration<SupportLimitedSerialLinkEntity>
{
    public void Configure(EntityTypeBuilder<SupportLimitedSerialLinkEntity> builder)
    {
        builder.ToTable("SupportLimitedSerialLink");
        builder.HasKey(e => new { e.SupportId, e.SerialId, });
    }
}
