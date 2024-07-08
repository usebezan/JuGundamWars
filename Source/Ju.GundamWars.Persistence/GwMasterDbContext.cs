using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ju.GundamWars.Persistence;

public class GwMasterDbContext : DbContext
{

    public GwMasterDbContext(DbContextOptions<GwMasterDbContext> options)
        : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // IEntityTypeConfiguration を継承した TypeConfiguration を適用
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
