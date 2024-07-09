using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileCoUnitConfig : IEntityTypeConfiguration<MobileCoUnit>
{

    public void Configure(EntityTypeBuilder<MobileCoUnit> builder)
    {
        builder.ToTable(nameof(MobileCoUnit));
        builder.HasKey(e => new { e.MobileId, e.Seq, });
    }

}
