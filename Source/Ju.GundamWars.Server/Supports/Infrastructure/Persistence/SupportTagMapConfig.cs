using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportTagMapConfig : IEntityTypeConfiguration<SupportTagMapDto>
{
    public void Configure(EntityTypeBuilder<SupportTagMapDto> builder)
    {
        builder.ToTable("SupportTagMap");
        builder.HasKey(e => new { e.SupportId, e.TagId, });
    }
}
