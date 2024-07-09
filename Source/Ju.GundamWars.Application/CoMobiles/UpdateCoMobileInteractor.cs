using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Mappers;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class UpdateCoUnitInteractor(
    ICoUnitRepository repository,
    CoUnitMapper entityMapper,
    CoUnitSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCoUnitInteractor> logger)
    : UpdateInteractorBase<CoUnit, CoUnitSubject, ICoUnitRepository, CoUnitMapper, CoUnitSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateCoUnitUseCase
{

    protected override string GetName(CoUnitSubject subject) => $"Co-Unit '{subject.Name}'";

}
