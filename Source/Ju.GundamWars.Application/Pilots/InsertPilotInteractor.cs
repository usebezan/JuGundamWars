using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Domain.Pilots.Mappers;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.Pilots.Domain.Factories;

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
