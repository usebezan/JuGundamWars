using Ju.GundamWars.Domain.Mobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileSupportConfig : IEntityTypeConfiguration<MobileSupport>
{

    public void Configure(EntityTypeBuilder<MobileSupport> builder)
    {
        builder.ToTable(nameof(MobileSupport));
        builder.HasKey(e => new { e.MobileId, e.Seq, });
    }

}
