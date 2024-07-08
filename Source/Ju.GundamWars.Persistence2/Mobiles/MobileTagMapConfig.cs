using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileTagMapConfig : IEntityTypeConfiguration<MobileTagMap>
{

    public void Configure(EntityTypeBuilder<MobileTagMap> builder)
    {
        builder.ToTable(nameof(MobileTagMap));
        builder.HasKey(e => new { e.MobileId, e.TagId, });
    }

}
