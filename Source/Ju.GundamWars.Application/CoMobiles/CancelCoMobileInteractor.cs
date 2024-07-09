using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.CoUnits.Mappers;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.CoUnits.Factories;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class CancelCoUnitInteractor(
    ICoUnitRepository repository,
    CoUnitFactory entityFactory,
    CoUnitSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelCoUnitInteractor> logger)
    : CancelInteractorBase<CoUnit, CoUnitSubject, ICoUnitRepository, CoUnitFactory, CoUnitSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelCoUnitUseCase
{
}
