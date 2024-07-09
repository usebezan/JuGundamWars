using Ju.GundamWars.Domain.CoUnits.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.CoMobiles;

public class CoUnitTagMapConfig : IEntityTypeConfiguration<CoUnitTagMap>
{

    public void Configure(EntityTypeBuilder<CoUnitTagMap> builder)
    {
        builder.ToTable(nameof(CoUnitTagMap));
        builder.HasKey(e => new { e.CoUnitId, e.TagId, });
    }

}
