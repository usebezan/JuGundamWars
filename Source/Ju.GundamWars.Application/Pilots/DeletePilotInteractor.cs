using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
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
