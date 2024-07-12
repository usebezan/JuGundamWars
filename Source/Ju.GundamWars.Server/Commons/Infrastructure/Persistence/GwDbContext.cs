using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public class GwDbContext(DbContextOptions<GwDbContext> options) : DbContext(options)
{

    //public IQueryable<Mobile> IncludedMobiles => Set<Mobile>()
    //    .Include(e => e.PairMaps)
    //    .Include(e => e.SubSerialMaps)
    //    .Include(e => e.TagMaps)
    //    .Include(e => e.PilotMaps)
    //    .Include(e => e.Cuspas)
    //    .Include(e => e.Supports)
    //    .Include(e => e.CoMobiles);



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // IEntityTypeConfiguration を継承した TypeConfiguration を適用
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
