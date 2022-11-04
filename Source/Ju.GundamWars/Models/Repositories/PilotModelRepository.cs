using Ju.GundamWars.Models.Entities;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Models.Repositories
{

    public class PilotModelRepository : DisposableBindableBase, IModelRepository<PilotModel>
    {

        public PilotModelRepository(PilotRepository repository)
        {
            Models = repository.Entities.ToReadOnlyReactiveCollection(e => new PilotModel(e, GetRequiredService<PilotRepository>())).AddTo(Disposables);
        }


        public ReadOnlyReactiveCollection<PilotModel> Models { get; }


        public PilotModel? GetModel(Pilot? entity) =>
            entity == null ? null : Models.FirstOrDefault(m => m.Entity.Id == entity.Id);

    }

}
