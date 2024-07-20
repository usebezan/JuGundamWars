using Ju.GundamWars.Application.Mobiles.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class InsertMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectMapper subjectMapper,
    IMobileInventory inventory,
    IEnterPresenter presenter,
    ILogger<InsertMobileInteractor> logger)
    : InsertInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectMapper, IMobileInventory>(repository, entityFactory, subjectMapper, subjectMapper, inventory, inventory, presenter, logger),
        IInsertMobileUseCase
{

    protected override string GetName(MobileSubject subject) => $"Mobile '{subject.Name}'";

}
