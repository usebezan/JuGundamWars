using Ju.GundamWars.Server.Cuspas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaConfig : IEntityTypeConfiguration<CuspaEntity>
{
    public void Configure(EntityTypeBuilder<CuspaEntity> builder)
    {
        builder.ToTable("Cuspa");
        builder.HasMany(e => e.TagLinks).WithOne(e => e.Cuspa).HasForeignKey(e => e.CuspaId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }
}
