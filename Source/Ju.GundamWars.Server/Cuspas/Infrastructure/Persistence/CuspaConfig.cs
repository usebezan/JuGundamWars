using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaConfig : IEntityTypeConfiguration<CuspaDto>
{
    public void Configure(EntityTypeBuilder<CuspaDto> builder)
    {
        builder.ToTable("Cuspa");
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Cuspa).HasForeignKey(e => e.CuspaId).IsRequired(false);
    }
}
