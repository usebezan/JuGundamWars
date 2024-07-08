using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobilePairMapConfig : IEntityTypeConfiguration<MobilePairMap>
{

    public void Configure(EntityTypeBuilder<MobilePairMap> builder)
    {
        builder.ToTable(nameof(MobilePairMap));
        builder.HasKey(e => new { e.MobileId, e.PairId, });
    }

}
