using Ju.GundamWars.Application.CoMobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class UpdateCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileMapper entityMapper,
    CoMobileSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCoMobileInteractor> logger)
    : UpdateInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileMapper, CoMobileSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
