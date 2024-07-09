using Ju.GundamWars.Domain;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application;

public abstract class DeleteInteractorBase<TEntity, TSubject, TRepository, TInventory>(
    TRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    TInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger logger)
    : IDeleteUseCase<TSubject>
    where TEntity : class
    where TSubject : class, IIdentify
    where TRepository : IRepository<TEntity>
    where TInventory : IInventory<TSubject>
{

    protected abstract string GetName(TSubject subject);

    public async Task<bool> HandleAsync(TSubject subject)
    {
        logger.LogDebug("HandleAsync start.");
        var name = GetName(subject);
        var isOk = await presenter.AskAsync("DELETE?", $"Are you sure you want to delete {name}?");
        if (isOk)
        {
            var (self, exes) = await repository.DeleteByIdAsync(subject.Id);
            exes?.ForEach(e =>
            {
                var i = mobileInventory.FirstOrDefault(i => i.Id == e.Id);
                if (i != null)
                {
                    mobileSubjectMapper.Apply(e, i);
                }
            });
            inventory.Remove(subject);
            presenter.Complete($"{name} deleted.");
        }
        logger.LogDebug("HandleAsync end.");
        return isOk;
    }

}
