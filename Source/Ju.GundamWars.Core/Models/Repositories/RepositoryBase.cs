using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Ju.GundamWars.Models.Repositories
{

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {

        public RepositoryBase(GwDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Entities = new();

            Load();
        }


        protected GwDbContext DbContext { get; }

        public ObservableCollection<TEntity> Entities { get; }


        protected abstract List<TEntity> SelectAll();

        protected List<TEntity> Select(Func<IQueryable<TEntity>, IQueryable<TEntity>> predicate) =>
            predicate(DbContext.Set<TEntity>()).ToList();

        public virtual void Load()
        {
            Entities.Clear();
            SelectAll().ForEach(e => Entities.Add(e));
        }

        public virtual void Insert(TEntity entity)
        {
            Execute(db =>
            {
                db.Set<TEntity>().Add(entity);
            });
            Entities.Add(entity);
        }

        public virtual void Update(TEntity entity) =>
            Execute(db =>
            {
                // Do nothing special. Just SaveChanges.
                //db.Set<TEntity>().Update(entity);
                //db.Set<TEntity>().Attach(entity);
            });

        public virtual void Delete(TEntity entity)
        {
            Execute(db =>
            {
                db.Set<TEntity>().Remove(entity);
            });
            Entities.Remove(entity);
        }

        public virtual void Reload(TEntity entity)
        {
            DbContext.Entry(entity).Reload();
        }

        public virtual bool IsDirty(TEntity entity)
        {
            return DbContext.Entry(entity).State != EntityState.Unchanged;
        }

        public virtual TEntity CloneEntity(TEntity entity)
        {
            var clone = DbContext.Entry(entity).CurrentValues.Clone().ToObject() as TEntity;
            return clone ?? throw new InvalidCastException();
        }

        protected void Execute(Action<GwDbContext> executor)
        {
            executor(DbContext);
#if DEBUG
            DbContext.ChangeTracker.DetectChanges();
            Debug.WriteLine(DbContext.ChangeTracker.DebugView.LongView);
#endif
            DbContext.SaveChanges();
        }

    }

}
