using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class InsertMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectApplier subjectApplier,
    IMobileInventory inventory,
    IEnterPresenter presenter,
    ILogger<InsertMobileInteractor> logger)
    : InsertInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectApplier, IMobileInventory>(repository, entityFactory, subjectApplier, subjectApplier, inventory, inventory, presenter, logger),
        IInsertMobileUseCase
{

    protected override string GetName(MobileSubject subject) => $"Mobile '{subject.Name}'";

}
