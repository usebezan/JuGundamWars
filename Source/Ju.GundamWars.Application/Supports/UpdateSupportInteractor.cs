using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class UpdateSupportInteractor(
    ISupportRepository repository,
    SupportApplier entityApplier,
    SupportSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateSupportInteractor> logger)
    : UpdateInteractorBase<Support, SupportSubject, ISupportRepository, SupportApplier, SupportSubjectApplier>(repository, entityApplier, subjectApplier, mobileSubjectApplier, mobileInventory, presenter, logger),
        IUpdateSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
