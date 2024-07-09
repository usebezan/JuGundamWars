using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Mappers;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.CoUnits.Factories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class InsertCoUnitInteractor(
    ICoUnitRepository repository,
    CoUnitFactory entityFactory,
    CoUnitSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ICoUnitInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertCoUnitInteractor> logger)
    : InsertInteractorBase<CoUnit, CoUnitSubject, ICoUnitRepository, CoUnitFactory, CoUnitSubjectMapper, ICoUnitInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertCoUnitUseCase
{

    protected override string GetName(CoUnitSubject subject) => $"Co-Unit '{subject.Name}'";

}
