using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class CancelMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectApplier subjectApplier,
    IEnterPresenter presenter,
    ILogger<CancelMobileInteractor> logger)
    : CancelInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectApplier>(repository, entityFactory, subjectApplier, presenter, logger),
        ICancelMobileUseCase
{
}
