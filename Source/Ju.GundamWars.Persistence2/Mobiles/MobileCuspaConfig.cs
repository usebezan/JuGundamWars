using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileCuspaConfig : IEntityTypeConfiguration<MobileCuspa>
{

    public void Configure(EntityTypeBuilder<MobileCuspa> builder)
    {
        builder.ToTable(nameof(MobileCuspa));
        builder.HasKey(e => new { e.MobileId, e.Seq, });
    }

}
