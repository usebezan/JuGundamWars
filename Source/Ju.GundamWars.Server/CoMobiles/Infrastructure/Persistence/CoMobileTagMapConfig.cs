using Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileTagMapConfig : IEntityTypeConfiguration<CoMobileTagMapDto>
{
    public void Configure(EntityTypeBuilder<CoMobileTagMapDto> builder)
    {
        builder.ToTable("CoMobileTagMap");
        builder.HasKey(e => new { e.CoMobileId, e.TagId, });
    }
}
