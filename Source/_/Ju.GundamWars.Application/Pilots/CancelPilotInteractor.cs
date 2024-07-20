using Ju.GundamWars.Application.Pilots.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class CancelPilotInteractor(
    IPilotRepository repository,
    PilotFactory entityFactory,
    PilotSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelPilotInteractor> logger)
    : CancelInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotFactory, PilotSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelPilotUseCase
{
}
