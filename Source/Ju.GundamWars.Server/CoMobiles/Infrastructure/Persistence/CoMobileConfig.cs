using Ju.GundamWars.Server.CoMobiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileConfig : IEntityTypeConfiguration<CoMobileEntity>
{
    public void Configure(EntityTypeBuilder<CoMobileEntity> builder)
    {
        builder.ToTable("CoMobile");
        builder.HasMany(e => e.TagMaps).WithOne(e => e.CoMobile).HasForeignKey(e => e.CoMobileId).IsRequired(false);
    }
}
