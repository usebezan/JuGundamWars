using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobilePilotMapConfig : IEntityTypeConfiguration<MobilePilotMap>
{

    public void Configure(EntityTypeBuilder<MobilePilotMap> builder)
    {
        builder.ToTable(nameof(MobilePilotMap));
        builder.HasKey(e => new { e.MobileId, e.PilotId, });
    }

}
