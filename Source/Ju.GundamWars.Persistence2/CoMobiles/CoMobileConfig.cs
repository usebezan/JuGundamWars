using Ju.GundamWars.Domain.CoMobiles.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.CoMobiles;

public class CoMobileConfig : IEntityTypeConfiguration<CoMobile>
{

    public void Configure(EntityTypeBuilder<CoMobile> builder)
    {
        builder.ToTable(nameof(CoMobile));
        builder.HasMany(e => e.TagMaps).WithOne(e => e.CoMobile).HasForeignKey(e => e.CoMobileId).IsRequired(false);
    }

}
