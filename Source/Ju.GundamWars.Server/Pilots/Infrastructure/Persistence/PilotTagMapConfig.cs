using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotTagMapConfig : IEntityTypeConfiguration<PilotTagMapDto>
{
    public void Configure(EntityTypeBuilder<PilotTagMapDto> builder)
    {
        builder.ToTable("PilotTagMap");
        builder.HasKey(e => new { e.PilotId, e.TagId, });
    }
}
