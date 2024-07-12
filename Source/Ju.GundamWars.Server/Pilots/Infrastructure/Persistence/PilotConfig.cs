using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotConfig : IEntityTypeConfiguration<PilotDto>
{
    public void Configure(EntityTypeBuilder<PilotDto> builder)
    {
        builder.ToTable("Pilot");
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Pilot).HasForeignKey(e => e.PilotId).IsRequired(false);
    }
}
