using Ju.GundamWars.Pilots.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Pilots;

public class PilotConfig : IEntityTypeConfiguration<Pilot>
{

    public void Configure(EntityTypeBuilder<Pilot> builder)
    {
        builder.ToTable(nameof(Pilot));
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Pilot).HasForeignKey(e => e.PilotId).IsRequired(false);
    }

}
