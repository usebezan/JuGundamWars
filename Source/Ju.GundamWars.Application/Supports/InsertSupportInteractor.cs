using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class InsertSupportInteractor(
    ISupportRepository repository,
    SupportFactory entityFactory,
    SupportSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    ISupportInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertSupportInteractor> logger)
    : InsertInteractorBase<Support, SupportSubject, ISupportRepository, SupportFactory, SupportSubjectApplier, ISupportInventory>(repository, entityFactory, subjectApplier, mobileSubjectApplier, inventory, mobileInventory, presenter, logger),
        IInsertSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
