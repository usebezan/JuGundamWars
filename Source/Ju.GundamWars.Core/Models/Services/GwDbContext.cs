using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using Version = Ju.GundamWars.Models.Entities.Version;


namespace Ju.GundamWars.Models.Services
{

    public class GwDbContext : DbContext
    {

        public GwDbContext(DbContextOptions<GwDbContext> options) : base(options) { }


        public DbSet<Version> Versions => Set<Version>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // IEntityTypeConfiguration を継承した DbConfiguration を適用
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}
