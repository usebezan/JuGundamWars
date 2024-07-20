using Ju.GundamWars.Application.Supports.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class UpdateSupportInteractor(
    ISupportRepository repository,
    SupportMapper entityMapper,
    SupportSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateSupportInteractor> logger)
    : UpdateInteractorBase<Support, SupportSubject, ISupportRepository, SupportMapper, SupportSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
