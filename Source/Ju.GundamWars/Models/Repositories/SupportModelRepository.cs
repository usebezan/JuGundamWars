using Ju.GundamWars.Models.Entities;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;


namespace Ju.GundamWars.Models.Repositories
{

    public class SupportModelRepository : DisposableBindableBase, IModelRepository<SupportModel>
    {

        public SupportModelRepository(SupportRepository repository)
        {
            Models = repository.Entities.ToReadOnlyReactiveCollection(SupportModel.Create).AddTo(Disposables);
        }


        public ReadOnlyReactiveCollection<SupportModel> Models { get; }


        public SupportModel? GetModel(Support? entity) =>
            entity == null ? null : Models.FirstOrDefault(m => m.Entity.Id == entity.Id);

    }

}
