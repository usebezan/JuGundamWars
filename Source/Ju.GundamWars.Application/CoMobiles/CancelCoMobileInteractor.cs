using Ju.GundamWars.Application.CoMobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class CancelCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileFactory entityFactory,
    CoMobileSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelCoMobileInteractor> logger)
    : CancelInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileFactory, CoMobileSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelCoMobileUseCase
{
}
