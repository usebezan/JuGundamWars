using Ju.GundamWars.Domain.CoMobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.CoMobiles;

public class CoMobileTagMapConfig : IEntityTypeConfiguration<CoMobileTagMap>
{

    public void Configure(EntityTypeBuilder<CoMobileTagMap> builder)
    {
        builder.ToTable(nameof(CoMobileTagMap));
        builder.HasKey(e => new { e.CoMobileId, e.TagId, });
    }

}
