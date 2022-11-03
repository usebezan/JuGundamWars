using Ju.GundamWars.Models.Entities;
using System;
using System.Collections.ObjectModel;


namespace Ju.GundamWars.Models.Repositories
{

    public interface IRepository
    {

        public void Load();

    }

    public interface IRepository<TEntity> : IRepository
        where TEntity : class, IEntity
    {

        public ObservableCollection<TEntity> Entities { get; }


        public void Insert(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public void Reload(TEntity entity);
        public bool IsDirty(TEntity entity);
        public TEntity CloneEntity(TEntity entity);

    }

}
