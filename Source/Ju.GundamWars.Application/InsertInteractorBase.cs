using Ju.GundamWars.Domain;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application;

public abstract class InsertInteractorBase<TEntity, TSubject, TRepository, TEntityFactory, TSubjectApplier, TInventory>(
    TRepository repository,
    TEntityFactory entityFactory,
    TSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    TInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger logger)
    : IInsertUseCase<TSubject>
    where TEntity : class
    where TSubject : GwObservableValidator
    where TRepository : IRepository<TEntity>
    where TEntityFactory : IFactory<TSubject, TEntity>
    where TSubjectApplier : IApplier<TEntity, TSubject>
    where TInventory : IInventory<TSubject>
{

    protected abstract string GetName(TSubject subject);

    public async Task HandleAsync(TSubject subject)
    {
        logger.LogDebug("HandleAsync start.");
        var name = GetName(subject);
        subject.ValidateAllProperties();
        if (subject.HasErrors)
        {
            presenter.Abort("Has errors!");
            return;
        }
        var (self, exes) = await repository.InsertAsync(entityFactory.Create(subject));
        exes?.ForEach(e =>
        {
            var i = mobileInventory.FirstOrDefault(i => i.Id == e.Id);
            if (i != null)
            {
                mobileSubjectApplier.Apply(e, i);
            }
        });
        inventory.Add(subjectApplier.Apply(self, subject));
        presenter.Complete($"{name} registered.");
        logger.LogDebug("HandleAsync end.");
    }

}
