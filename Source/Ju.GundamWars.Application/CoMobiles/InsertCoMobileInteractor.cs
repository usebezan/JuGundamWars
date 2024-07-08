using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.CoMobiles.Factories;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class InsertCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileFactory entityFactory,
    CoMobileSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    ICoMobileInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertCoMobileInteractor> logger)
    : InsertInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileFactory, CoMobileSubjectApplier, ICoMobileInventory>(repository, entityFactory, subjectApplier, mobileSubjectApplier, inventory, mobileInventory, presenter, logger),
        IInsertCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
