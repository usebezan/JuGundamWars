using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileSubSerialMapConfig : IEntityTypeConfiguration<MobileSubSerialMap>
{

    public void Configure(EntityTypeBuilder<MobileSubSerialMap> builder)
    {
        builder.ToTable(nameof(MobileSubSerialMap));
        builder.HasKey(e => new { e.MobileId, e.SerialId, });
    }

}
