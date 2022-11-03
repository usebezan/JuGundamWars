using Ju.GundamWars.Models.Entities;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;


namespace Ju.GundamWars.Models.Repositories
{

    public class PilotModelRepository : DisposableBindableBase, IModelRepository<PilotModel>
    {

        public PilotModelRepository(PilotRepository repository)
        {
            Models = repository.Entities.ToReadOnlyReactiveCollection(PilotModel.Create).AddTo(Disposables);
        }


        public ReadOnlyReactiveCollection<PilotModel> Models { get; }


        public PilotModel? GetModel(Pilot? entity) =>
            entity == null ? null : Models.FirstOrDefault(m => m.Entity.Id == entity.Id);

    }

}
