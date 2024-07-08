using Ju.GundamWars.Domain.Versionings.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Versionings;

public class VersioningConfig : IEntityTypeConfiguration<Versioning>
{

    public void Configure(EntityTypeBuilder<Versioning> builder)
    {
        builder.ToTable(nameof(Versioning));
    }

}
