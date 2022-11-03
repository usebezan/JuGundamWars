using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;


namespace Ju.GundamWars.Models.Services
{

    public class GwDbContext : DbContext
    {

        public GwDbContext(DbContextOptions<GwDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // IEntityTypeConfiguration を継承した DbConfiguration を適用
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}
