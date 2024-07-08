using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class DeleteCoMobileInteractor(
    ICoMobileRepository repository,
    MobileSubjectApplier mobileSubjectApplier,
    ICoMobileInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteCoMobileInteractor> logger)
    : DeleteInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, ICoMobileInventory>(repository, mobileSubjectApplier, inventory, mobileInventory, presenter, logger),
        IDeleteCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
