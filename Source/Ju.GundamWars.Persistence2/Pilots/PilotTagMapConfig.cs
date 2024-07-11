using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Pilots;

public class PilotTagMapConfig : IEntityTypeConfiguration<PilotTagMap>
{

    public void Configure(EntityTypeBuilder<PilotTagMap> builder)
    {
        builder.ToTable(nameof(PilotTagMap));
        builder.HasKey(e => new { e.PilotId, e.TagId, });
    }

}
