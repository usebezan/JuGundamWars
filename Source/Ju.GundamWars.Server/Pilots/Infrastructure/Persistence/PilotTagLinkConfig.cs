using Ju.GundamWars.Server.Pilots.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotTagLinkConfig : IEntityTypeConfiguration<PilotTagLinkEntity>
{
    public void Configure(EntityTypeBuilder<PilotTagLinkEntity> builder)
    {
        builder.ToTable("PilotTagLink");
        builder.HasKey(e => new { e.PilotId, e.TagId, });
    }
}
