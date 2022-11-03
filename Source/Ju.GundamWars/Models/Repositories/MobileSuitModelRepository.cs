using Ju.GundamWars.Models.Entities;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;


namespace Ju.GundamWars.Models.Repositories
{

    public class MobileSuitModelRepository : DisposableBindableBase, IModelRepository<MobileSuitModel>
    {

        public MobileSuitModelRepository(MobileSuitRepository repository)
        {
            Models = repository.Entities.ToReadOnlyReactiveCollection(MobileSuitModel.Create).AddTo(Disposables);
        }


        public ReadOnlyReactiveCollection<MobileSuitModel> Models { get; }


        public MobileSuitModel? GetModel(MobileSuit? entity) =>
            entity == null ? null : Models.FirstOrDefault(m => m.Entity.Id == entity.Id);

    }

}
