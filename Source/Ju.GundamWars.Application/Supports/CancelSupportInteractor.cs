using Ju.GundamWars.Application.Supports.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class CancelSupportInteractor(
    ISupportRepository repository,
    SupportFactory entityFactory,
    SupportSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelSupportInteractor> logger)
    : CancelInteractorBase<Support, SupportSubject, ISupportRepository, SupportFactory, SupportSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelSupportUseCase
{
}
