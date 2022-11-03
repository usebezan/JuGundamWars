using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using System;


namespace Ju.GundamWars.Models
{

    public abstract class ModelBase<TEntity, TRepository> : DisposableBindableBase, IModel
        where TEntity : BindableBase, IEntity
        where TRepository : IRepository<TEntity>
    {

        public ModelBase(TEntity entity, TRepository repository)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        protected TRepository Repository { get; }

        public TEntity Entity { get; private set; }


        public virtual void Insert() =>
            Repository.Insert(Entity);

        public virtual void Update() =>
            Repository.Update(Entity);

        public virtual void Delete() =>
            Repository.Delete(Entity);

        public virtual void Reload() =>
            Repository.Reload(Entity);

        public virtual bool IsDirty() =>
            Repository.IsDirty(Entity);

        public virtual TEntity CloneEntity() =>
            Repository.CloneEntity(Entity);

    }

}
