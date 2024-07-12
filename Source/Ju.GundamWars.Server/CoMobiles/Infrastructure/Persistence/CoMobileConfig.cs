using Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileConfig : IEntityTypeConfiguration<CoMobileDto>
{
    public void Configure(EntityTypeBuilder<CoMobileDto> builder)
    {
        builder.ToTable("CoMobile");
        builder.HasMany(e => e.TagMaps).WithOne(e => e.CoMobile).HasForeignKey(e => e.CoMobileId).IsRequired(false);
    }
}
