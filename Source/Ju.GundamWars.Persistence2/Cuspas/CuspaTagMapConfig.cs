using Ju.GundamWars.Domain.Cuspas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Cuspas;

public class CuspaTagMapConfig : IEntityTypeConfiguration<CuspaTagMap>
{

    public void Configure(EntityTypeBuilder<CuspaTagMap> builder)
    {
        builder.ToTable(nameof(CuspaTagMap));
        builder.HasKey(e => new { e.CuspaId, e.TagId, });
    }

}
