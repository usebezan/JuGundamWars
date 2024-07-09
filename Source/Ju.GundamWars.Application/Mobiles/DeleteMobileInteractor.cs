using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class DeleteMobileInteractor(
    IMobileRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory inventory,
    IPilotInventory pilotInventory,
    ISupportInventory supportInventory,
    ICoUnitInventory CoUnitInventory,
    IEnterPresenter presenter,
    ILogger<DeleteMobileInteractor> logger)
    : IDeleteMobileUseCase
{

    public async Task<bool> HandleAsync(MobileSubject subject)
    {
        logger.LogDebug("HandleAsync start.");
        var isOk = await presenter.AskAsync("DELETE?", $"Are you sure you want to delete Mobile '{subject.Name}'?");
        if (isOk)
        {
            var entity = repository.SelectById(subject.Id);

            var (self, exes) = await repository.DeleteByIdAsync(subject.Id);
            exes?.ForEach(e =>
            {
                var i = inventory.FirstOrDefault(i => i.Id == e.Id);
                if (i != null)
                {
                    mobileSubjectMapper.Apply(e, i);
                }
            });
            inventory.Remove(subject);

            if (entity != null)
            {
                inventory.Where(i => entity.PairMaps.Any(r => r.PairId == i.Id)).ToList().ForEach(i => i.Pair = null);
                pilotInventory.Where(i => entity.PilotMaps.Any(r => r.PilotId == i.Id)).ToList().ForEach(i => i.Mobile = null);
                supportInventory.Where(i => entity.Supports.Any(r => r.SupportId == i.Id)).ToList().ForEach(i => i.Mobile = null);
                CoUnitInventory.Where(i => entity.CoUnits.Any(r => r.CoUnitId == i.Id)).ToList().ForEach(i => i.Mobile = null);
            }

            presenter.Complete($"Mobile '{subject.Name}' deleted.");
        }
        logger.LogDebug("HandleAsync end.");
        return isOk;
    }

}
