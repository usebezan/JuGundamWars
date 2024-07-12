using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Ju.GundamWars.Server;

public static class PersistenceExtension
{

    public static EntityEntry<TEntity> Remove<TEntity>(this DbSet<TEntity> self, Expression<Func<TEntity, bool>> predicate) where TEntity : class =>
        self.Remove(self.First(predicate));

    public static void RemoveRange<TEntity>(this DbSet<TEntity> self, Expression<Func<TEntity, bool>> predicate) where TEntity : class =>
        self.RemoveRange(self.Where(predicate));

    public static void RemoveAll<TEntity>(this DbSet<TEntity> self) where TEntity : class =>
        self.RemoveRange(self.ToList());

}
