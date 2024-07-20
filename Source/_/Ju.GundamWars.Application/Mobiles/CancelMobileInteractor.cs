using Ju.GundamWars.Application.Mobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class CancelMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelMobileInteractor> logger)
    : CancelInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelMobileUseCase
{
}
