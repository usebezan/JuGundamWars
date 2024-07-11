using Ju.GundamWars.Application.CoMobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class InsertCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileFactory entityFactory,
    CoMobileSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ICoMobileInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertCoMobileInteractor> logger)
    : InsertInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileFactory, CoMobileSubjectMapper, ICoMobileInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
