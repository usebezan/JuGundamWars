using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Cuspas.Appliers;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class UpdateCuspaInteractor(
    ICuspaRepository repository,
    CuspaApplier entityApplier,
    CuspaSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCuspaInteractor> logger)
    : UpdateInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaApplier, CuspaSubjectApplier>(repository, entityApplier, subjectApplier, mobileSubjectApplier, mobileInventory, presenter, logger),
        IUpdateCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
