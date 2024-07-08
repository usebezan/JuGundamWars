using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Pilots.Factories;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class CancelPilotInteractor(
    IPilotRepository repository,
    PilotFactory entityFactory,
    PilotSubjectApplier subjectApplier,
    IEnterPresenter presenter,
    ILogger<CancelPilotInteractor> logger)
    : CancelInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotFactory, PilotSubjectApplier>(repository, entityFactory, subjectApplier, presenter, logger),
        ICancelPilotUseCase
{
}
