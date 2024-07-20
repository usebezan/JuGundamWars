using Ju.GundamWars.Application.Pilots.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class DeletePilotInteractor(
    IPilotRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    IPilotInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeletePilotInteractor> logger)
    : DeleteInteractorBase<Pilot, PilotSubject, IPilotRepository, IPilotInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeletePilotUseCase
{

    protected override string GetName(PilotSubject subject) => $"Pilot '{subject.Name}'";

}
