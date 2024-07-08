using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileCoMobileConfig : IEntityTypeConfiguration<MobileCoMobile>
{

    public void Configure(EntityTypeBuilder<MobileCoMobile> builder)
    {
        builder.ToTable(nameof(MobileCoMobile));
        builder.HasKey(e => new { e.MobileId, e.Seq, });
    }

}
