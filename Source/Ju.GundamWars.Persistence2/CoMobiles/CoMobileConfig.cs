using Ju.GundamWars.Domain.CoUnits.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.CoMobiles;

public class CoUnitConfig : IEntityTypeConfiguration<CoUnit>
{

    public void Configure(EntityTypeBuilder<CoUnit> builder)
    {
        builder.ToTable(nameof(CoUnit));
        builder.HasMany(e => e.TagMaps).WithOne(e => e.CoUnit).HasForeignKey(e => e.CoUnitId).IsRequired(false);
    }

}
