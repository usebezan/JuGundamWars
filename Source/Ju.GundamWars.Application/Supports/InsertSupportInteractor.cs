using Ju.GundamWars.Application.Supports.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class InsertSupportInteractor(
    ISupportRepository repository,
    SupportFactory entityFactory,
    SupportSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ISupportInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertSupportInteractor> logger)
    : InsertInteractorBase<Support, SupportSubject, ISupportRepository, SupportFactory, SupportSubjectMapper, ISupportInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
