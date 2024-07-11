using Ju.GundamWars.Application.Cuspas.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class CancelCuspaInteractor(
    ICuspaRepository repository,
    CuspaFactory entityFactory,
    CuspaSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelCuspaInteractor> logger)
    : CancelInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaFactory, CuspaSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelCuspaUseCase
{
}
