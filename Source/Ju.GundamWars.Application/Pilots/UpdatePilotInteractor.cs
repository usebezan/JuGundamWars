using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Pilots;

public class UpdatePilotInteractor(
    IPilotRepository repository,
    PilotApplier entityApplier,
    PilotSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdatePilotInteractor> logger)
    : UpdateInteractorBase<Pilot, PilotSubject, IPilotRepository, PilotApplier, PilotSubjectApplier>(repository, entityApplier, subjectApplier, mobileSubjectApplier, mobileInventory, presenter, logger),
        IUpdatePilotUseCase
{

    protected override string GetName(PilotSubject subject) => $"Pilot '{subject.Name}'";

}
