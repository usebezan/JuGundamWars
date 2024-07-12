using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.Versionings.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public class GwMasterDbContext(DbContextOptions<GwMasterDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PilotAbilityDto>().ToTable("PilotAbility");
        modelBuilder.Entity<SerialDto>().ToTable("Serial");
        modelBuilder.Entity<SkillDto>().ToTable("Skill");
        modelBuilder.Entity<SupportBadgeDto>().ToTable("SupportBadge");
        modelBuilder.Entity<SupportSlotDto>().ToTable("SupportSlot");
        modelBuilder.Entity<VersioningDto>().ToTable("Versioning");
    }
}
