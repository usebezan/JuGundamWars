using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Pilots.Mappers;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.Pilots.Domain.Factories;

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
