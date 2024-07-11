using Ju.GundamWars.Application.Pilots.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class InsertPilotInteractor(
    IPilotRepository repository,
    PilotFactory entityFactory,
    PilotSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IPilotInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertPilotInteractor> logger)
    : InsertInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotFactory, PilotSubjectMapper, IPilotInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertPilotUseCase
{

    protected override string GetName(PilotSubject subject) => $"Pilot '{subject.Name}'";

}
