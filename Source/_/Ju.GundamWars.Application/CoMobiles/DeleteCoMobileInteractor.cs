using Ju.GundamWars.Application.CoMobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class DeleteCoMobileInteractor(
    ICoMobileRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    ICoMobileInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteCoMobileInteractor> logger)
    : DeleteInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, ICoMobileInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeleteCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
