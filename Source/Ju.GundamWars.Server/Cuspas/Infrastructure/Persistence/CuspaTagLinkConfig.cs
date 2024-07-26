using Ju.GundamWars.Server.Cuspas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaTagLinkConfig : IEntityTypeConfiguration<CuspaTagLinkEntity>
{
    public void Configure(EntityTypeBuilder<CuspaTagLinkEntity> builder)
    {
        builder.ToTable("CuspaTagLink");
        builder.HasKey(e => new { e.CuspaId, e.TagId, });
    }
}
