using Ju.GundamWars.Server.Supports.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportTagLinkConfig : IEntityTypeConfiguration<SupportTagLinkEntity>
{
    public void Configure(EntityTypeBuilder<SupportTagLinkEntity> builder)
    {
        builder.ToTable("SupportTagLink");
        builder.HasKey(e => new { e.SupportId, e.TagId, });
    }
}
