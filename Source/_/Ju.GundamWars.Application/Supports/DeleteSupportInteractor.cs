using Ju.GundamWars.Application.Supports.Repositories;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class DeleteSupportInteractor(
    ISupportRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    ISupportInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteSupportInteractor> logger)
    : DeleteInteractorBase<Support, SupportSubject, ISupportRepository, ISupportInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeleteSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
