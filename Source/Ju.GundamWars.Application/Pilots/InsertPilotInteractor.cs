using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Pilots.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class InsertPilotInteractor(
    IPilotRepository repository,
    PilotFactory entityFactory,
    PilotSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IPilotInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertPilotInteractor> logger)
    : InsertInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotFactory, PilotSubjectApplier, IPilotInventory>(repository, entityFactory, subjectApplier, mobileSubjectApplier, inventory, mobileInventory, presenter, logger),
        IInsertPilotUseCase
{

    protected override string GetName(PilotSubject subject) => $"Pilot '{subject.Name}'";

}
