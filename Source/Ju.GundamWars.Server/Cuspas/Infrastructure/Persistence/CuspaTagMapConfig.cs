using Ju.GundamWars.Server.Cuspas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaTagMapConfig : IEntityTypeConfiguration<CuspaTagMapEntity>
{
    public void Configure(EntityTypeBuilder<CuspaTagMapEntity> builder)
    {
        builder.ToTable("CuspaTagMap");
        builder.HasKey(e => new { e.CuspaId, e.TagId, });
    }
}
