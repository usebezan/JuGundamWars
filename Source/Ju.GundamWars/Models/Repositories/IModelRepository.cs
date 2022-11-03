using Reactive.Bindings;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public interface IModelRepository<TModel>
        where TModel : DisposableBindableBase, IModel
    {

        public ReadOnlyReactiveCollection<TModel> Models { get; }

    }

}
