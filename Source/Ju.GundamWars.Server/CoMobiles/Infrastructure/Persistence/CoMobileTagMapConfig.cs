using Ju.GundamWars.Server.CoMobiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileTagMapConfig : IEntityTypeConfiguration<CoMobileTagMapEntity>
{
    public void Configure(EntityTypeBuilder<CoMobileTagMapEntity> builder)
    {
        builder.ToTable("CoMobileTagMap");
        builder.HasKey(e => new { e.CoMobileId, e.TagId, });
    }
}
