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

        builder.OwnsOne(e => e.BonusStatus, b =>
        {
            b.Property(e => e.Hp).HasColumnName("BonusHp");
            b.Property(e => e.BeamAttack).HasColumnName("BonusBeamAttack");
            b.Property(e => e.PhysicalAttack).HasColumnName("BonusPhysicalAttack");
            b.Property(e => e.BeamDefence).HasColumnName("BonusBeamDefence");
            b.Property(e => e.PhysicalDefence).HasColumnName("BonusPhysicalDefence");
            b.Property(e => e.CriticalRate).HasColumnName("BonusCriticalRate");
            b.Property(e => e.CriticalDamage).HasColumnName("BonusCriticalDamage");
            b.Property(e => e.Accuracy).HasColumnName("BonusAccuracy");
            b.Property(e => e.Evasion).HasColumnName("BonusEvasion");
            b.Property(e => e.Mobility).HasColumnName("BonusMobility");
            b.Property(e => e.EnRecovery).HasColumnName("BonusEnRecovery");
        });
    }
}
