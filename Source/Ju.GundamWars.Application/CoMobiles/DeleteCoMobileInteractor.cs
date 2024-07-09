using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class DeleteCoUnitInteractor(
    ICoUnitRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    ICoUnitInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteCoUnitInteractor> logger)
    : DeleteInteractorBase<CoUnit, CoUnitSubject, ICoUnitRepository, ICoUnitInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeleteCoUnitUseCase
{

    protected override string GetName(CoUnitSubject subject) => $"Co-Unit '{subject.Name}'";

}
