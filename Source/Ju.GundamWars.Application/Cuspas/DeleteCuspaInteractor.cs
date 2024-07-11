using Ju.GundamWars.Application.Cuspas.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class DeleteCuspaInteractor(
    ICuspaRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    ICuspaInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteCuspaInteractor> logger)
    : DeleteInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, ICuspaInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeleteCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
