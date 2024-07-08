using Ju.GundamWars.Domain.Supports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Supports;

public class SupportTagMapConfig : IEntityTypeConfiguration<SupportTagMap>
{

    public void Configure(EntityTypeBuilder<SupportTagMap> builder)
    {
        builder.ToTable(nameof(SupportTagMap));
        builder.HasKey(e => new { e.SupportId, e.TagId, });
    }

}
