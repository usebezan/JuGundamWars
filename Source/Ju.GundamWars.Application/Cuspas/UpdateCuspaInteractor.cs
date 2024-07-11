using Ju.GundamWars.Application.Cuspas.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class UpdateCuspaInteractor(
    ICuspaRepository repository,
    CuspaMapper entityMapper,
    CuspaSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCuspaInteractor> logger)
    : UpdateInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaMapper, CuspaSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
