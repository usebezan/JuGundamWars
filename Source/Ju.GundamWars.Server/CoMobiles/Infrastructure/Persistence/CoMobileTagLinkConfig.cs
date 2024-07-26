using Ju.GundamWars.Server.CoMobiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileTagLinkConfig : IEntityTypeConfiguration<CoMobileTagLinkEntity>
{
    public void Configure(EntityTypeBuilder<CoMobileTagLinkEntity> builder)
    {
        builder.ToTable("CoMobileTagLink");
        builder.HasKey(e => new { e.CoMobileId, e.TagId, });
    }
}
