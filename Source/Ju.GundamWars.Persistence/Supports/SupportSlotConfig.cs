using Ju.GundamWars.Domain.Supports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Persistence.Supports;

public class SupportSlotConfig : IEntityTypeConfiguration<SupportSlot>
{

    public void Configure(EntityTypeBuilder<SupportSlot> builder)
    {
        builder.ToTable(nameof(SupportSlot));
        builder.Ignore(e => e.Name);
        builder.Ignore(e => e.BoostText);
        builder.Ignore(e => e.BoostTarget);
        builder.Ignore(e => e.IsAttachable);
        builder.Ignore(e => e.IsBonusable);
    }

}
