using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaTagMapConfig : IEntityTypeConfiguration<CuspaTagMapDto>
{
    public void Configure(EntityTypeBuilder<CuspaTagMapDto> builder)
    {
        builder.ToTable("CuspaTagMap");
        builder.HasKey(e => new { e.CuspaId, e.TagId, });
    }
}
