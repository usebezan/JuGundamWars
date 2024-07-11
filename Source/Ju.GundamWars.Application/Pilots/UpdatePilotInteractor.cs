using Ju.GundamWars.Application.Pilots.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class UpdatePilotInteractor(
    IPilotRepository repository,
    PilotMapper entityMapper,
    PilotSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdatePilotInteractor> logger)
    : UpdateInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotMapper, PilotSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdatePilotUseCase
{

    protected override string GetName(PilotSubject subject) => $"Pilot '{subject.Name}'";

}
