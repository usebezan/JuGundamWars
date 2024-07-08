using Ju.GundamWars.Domain.Systems.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Serials;

public class SerialConfig : IEntityTypeConfiguration<Serial>
{

    public void Configure(EntityTypeBuilder<Serial> builder)
    {
        builder.ToTable(nameof(Serial));
    }

}
