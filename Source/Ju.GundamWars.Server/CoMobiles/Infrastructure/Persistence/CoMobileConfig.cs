using Ju.GundamWars.Server.CoMobiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileConfig : IEntityTypeConfiguration<CoMobileEntity>
{
    public void Configure(EntityTypeBuilder<CoMobileEntity> builder)
    {
        builder.ToTable("CoMobile");
        builder.HasMany(e => e.TagLinks).WithOne(e => e.CoMobile).HasForeignKey(e => e.CoMobileId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(e => e.BasicStatus, b =>
        {
            b.Property(e => e.Hp).HasColumnName("Hp");
            b.Property(e => e.BeamAttack).HasColumnName("BeamAttack");
            b.Property(e => e.PhysicalAttack).HasColumnName("PhysicalAttack");
            b.Property(e => e.BeamDefence).HasColumnName("BeamDefence");
            b.Property(e => e.PhysicalDefence).HasColumnName("PhysicalDefence");
            b.Property(e => e.CriticalDamage).HasColumnName("CriticalDamage");
            b.Property(e => e.Accuracy).HasColumnName("Accuracy");
            b.Property(e => e.Evasion).HasColumnName("Evasion");
            b.Property(e => e.Mobility).HasColumnName("Mobility");
        });
        builder.OwnsOne(e => e.UpgradedStatus, b =>
        {
            b.Property(e => e.Hp).HasColumnName("UpgradedHp");
            b.Property(e => e.BeamAttack).HasColumnName("UpgradedBeamAttack");
            b.Property(e => e.PhysicalAttack).HasColumnName("UpgradedPhysicalAttack");
            b.Property(e => e.BeamDefence).HasColumnName("UpgradedBeamDefence");
            b.Property(e => e.PhysicalDefence).HasColumnName("UpgradedPhysicalDefence");
            b.Property(e => e.CriticalDamage).HasColumnName("UpgradedCriticalDamage");
            b.Property(e => e.Accuracy).HasColumnName("UpgradedAccuracy");
            b.Property(e => e.Evasion).HasColumnName("UpgradedEvasion");
            b.Property(e => e.Mobility).HasColumnName("UpgradedMobility");
        });
    }
}
