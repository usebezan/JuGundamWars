using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Microsoft.EntityFrameworkCore;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public class GwMasterDbContext(DbContextOptions<GwMasterDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PilotAbilityEntity>().ToTable("PilotAbility");
        modelBuilder.Entity<SerialEntity>().ToTable("Serial");
        modelBuilder.Entity<SkillEntity>().ToTable("Skill");
        modelBuilder.Entity<SupportBadgeEntity>().ToTable("SupportBadge");
        //modelBuilder.Entity<SupportSlotDto>().ToTable("SupportSlot");
        //modelBuilder.Entity<VersioningDto>().ToTable("Versioning");
    }
}
