using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Supports;

public class SupportLimitedSerialMapConfig : IEntityTypeConfiguration<SupportLimitedSerialMap>
{

    public void Configure(EntityTypeBuilder<SupportLimitedSerialMap> builder)
    {
        builder.ToTable(nameof(SupportLimitedSerialMap));
        builder.HasKey(e => new { e.SupportId, e.SerialId, });
    }

}
