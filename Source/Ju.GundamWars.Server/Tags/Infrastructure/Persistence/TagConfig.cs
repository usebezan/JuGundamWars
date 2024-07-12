using Ju.GundamWars.BizTxn.Tags.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Tags.Infrastructure.Persistence;

public class TagConfig : IEntityTypeConfiguration<TagDto>
{
    public void Configure(EntityTypeBuilder<TagDto> builder)
    {
        builder.ToTable("Tag");
    }
}
