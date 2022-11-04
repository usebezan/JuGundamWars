using Ju.GundamWars.Models.Entities;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Models.Repositories
{

    public class SupportModelRepository : DisposableBindableBase, IModelRepository<SupportModel>
    {

        public SupportModelRepository(SupportRepository repository)
        {
            Models = repository.Entities.ToReadOnlyReactiveCollection(e => new SupportModel(e, GetRequiredService<SupportRepository>())).AddTo(Disposables);
        }


        public ReadOnlyReactiveCollection<SupportModel> Models { get; }


        public SupportModel? GetModel(Support? entity) =>
            entity == null ? null : Models.FirstOrDefault(m => m.Entity.Id == entity.Id);

    }

}
