using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
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
