using Ju.GundamWars.Server.Pilots.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotConfig : IEntityTypeConfiguration<PilotEntity>
{
    public void Configure(EntityTypeBuilder<PilotEntity> builder)
    {
        builder.ToTable("Pilot");
        builder.HasMany(e => e.TagLinks).WithOne(e => e.Pilot).HasForeignKey(e => e.PilotId).IsRequired(false).OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(e => e.BasicStatus, b =>
        {
            b.Property(e => e.Shooting).HasColumnName("Shooting");
            b.Property(e => e.Melee).HasColumnName("Melee");
            b.Property(e => e.Accuracy).HasColumnName("Accuracy");
            b.Property(e => e.Evasion).HasColumnName("Evasion");
            b.Property(e => e.Awakened).HasColumnName("Awakened");
            b.Property(e => e.Defense).HasColumnName("Defense");
        });
        builder.OwnsOne(e => e.PracticedStatus, b =>
        {
            b.Property(e => e.Shooting).HasColumnName("PracticedShooting");
            b.Property(e => e.Melee).HasColumnName("PracticedMelee");
            b.Property(e => e.Accuracy).HasColumnName("PracticedAccuracy");
            b.Property(e => e.Evasion).HasColumnName("PracticedEvasion");
            b.Property(e => e.Awakened).HasColumnName("PracticedAwakened");
            b.Property(e => e.Defense).HasColumnName("PracticedDefense");
        });
    }
}
