using Ju.GundamWars.Domain.Cuspas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence2.Cuspas;

public class CuspaConfig : IEntityTypeConfiguration<Cuspa>
{

    public void Configure(EntityTypeBuilder<Cuspa> builder)
    {
        builder.ToTable(nameof(Cuspa));
        builder.HasMany(e => e.TagMaps).WithOne(e => e.Cuspa).HasForeignKey(e => e.CuspaId).IsRequired(false);
    }

}
