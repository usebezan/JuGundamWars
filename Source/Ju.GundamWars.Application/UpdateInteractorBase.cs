using Ju.GundamWars.Domain;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application;

public abstract class UpdateInteractorBase<TEntity, TSubject, TRepository, TEntityApplier, TSubjectApplier>(
    TRepository repository,
    TEntityApplier entityApplier,
    TSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger logger)
    : IUpdateUseCase<TSubject>
    where TEntity : class, new()
    where TSubject : GwObservableValidator, IKeyValues
    where TRepository : IRepository<TEntity>
    where TEntityApplier : IApplier<TSubject, TEntity>
    where TSubjectApplier : IApplier<TEntity, TSubject>
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
        var entity = repository.Find(subject.KeyValues);
        if (entity == null)
        {
            presenter.Abort("No updates were found!");
            return;
        }
        var (self, exes) = await repository.UpdateAsync(entityApplier.Apply(subject, entity));
        exes?.ForEach(e =>
        {
            var i = mobileInventory.FirstOrDefault(i => i.Id == e.Id);
            if (i != null)
            {
                mobileSubjectApplier.Apply(e, i);
            }
        });
        subjectApplier.Apply(self, subject);
        presenter.Complete($"{name} registered.");
        logger.LogDebug("HandleAsync end.");
    }

}
