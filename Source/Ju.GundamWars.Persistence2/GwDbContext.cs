using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Supports.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ju.GundamWars.Persistence2;

public class GwDbContext : DbContext
{

    public GwDbContext(DbContextOptions<GwDbContext> options)
        : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    public IQueryable<CoMobile> IncludedCoMobiles => Set<CoMobile>()
        .Include(e => e.TagMaps);

    public IQueryable<Cuspa> IncludedCuspas => Set<Cuspa>()
        .Include(e => e.TagMaps);

    public IQueryable<Mobile> IncludedMobiles => Set<Mobile>()
        .Include(e => e.PairMaps)
        .Include(e => e.SubSerialMaps)
        .Include(e => e.TagMaps)
        .Include(e => e.PilotMaps)
        .Include(e => e.Cuspas)
        .Include(e => e.Supports)
        .Include(e => e.CoMobiles);

    public IQueryable<Pilot> IncludedPilots => Set<Pilot>()
        .Include(e => e.TagMaps);

    public IQueryable<Support> IncludedSupports => Set<Support>()
        .Include(e => e.LimitedSerialMaps)
        .Include(e => e.TagMaps)
        .Include(e => e.SlotBadges);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // IEntityTypeConfiguration を継承した TypeConfiguration を適用
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
