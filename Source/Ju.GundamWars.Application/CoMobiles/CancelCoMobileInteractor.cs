using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.CoMobiles.Factories;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class CancelCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileFactory entityFactory,
    CoMobileSubjectApplier subjectApplier,
    IEnterPresenter presenter,
    ILogger<CancelCoMobileInteractor> logger)
    : CancelInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileFactory, CoMobileSubjectApplier>(repository, entityFactory, subjectApplier, presenter, logger),
        ICancelCoMobileUseCase
{
}
