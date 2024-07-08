using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class DeleteSupportInteractor(
    ISupportRepository repository,
    MobileSubjectApplier mobileSubjectApplier,
    ISupportInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteSupportInteractor> logger)
    : DeleteInteractorBase<Support, SupportSubject, ISupportRepository, ISupportInventory>(repository, mobileSubjectApplier, inventory, mobileInventory, presenter, logger),
        IDeleteSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
