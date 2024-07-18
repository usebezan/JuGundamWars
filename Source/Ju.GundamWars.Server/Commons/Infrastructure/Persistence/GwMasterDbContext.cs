using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
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

        modelBuilder.Entity<MobileSSkillEntity>().ToTable("MobileSSkill");
        modelBuilder.Entity<PilotAbilityEntity>().ToTable("PilotAbility");
        modelBuilder.Entity<PilotSkillEntity>().ToTable("PilotSkill");
        modelBuilder.Entity<SerialEntity>().ToTable("Serial");
        modelBuilder.Entity<SkillEntity>().ToTable("Skill");
        modelBuilder.Entity<SupportBadgeEntity>().ToTable("SupportBadge");
        modelBuilder.Entity<SupportSlotEntity>().ToTable("SupportSlot");
        modelBuilder.Entity<VersioningEntity>().ToTable("Versioning");
    }
}
