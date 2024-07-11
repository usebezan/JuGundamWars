using Ju.GundamWars.Application.Cuspas.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class InsertCuspaInteractor(
    ICuspaRepository repository,
    CuspaFactory entityFactory,
    CuspaSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ICuspaInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertCuspaInteractor> logger)
    : InsertInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaFactory, CuspaSubjectMapper, ICuspaInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
