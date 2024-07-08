using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.CoMobiles;

public class UpdateCoMobileInteractor(
    ICoMobileRepository repository,
    CoMobileApplier entityApplier,
    CoMobileSubjectApplier subjectApplier,
    MobileSubjectApplier mobileSubjectApplier,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCoMobileInteractor> logger)
    : UpdateInteractorBase<CoMobile, CoMobileSubject, ICoMobileRepository, CoMobileApplier, CoMobileSubjectApplier>(repository, entityApplier, subjectApplier, mobileSubjectApplier, mobileInventory, presenter, logger),
        IUpdateCoMobileUseCase
{

    protected override string GetName(CoMobileSubject subject) => $"Co-Unit '{subject.Name}'";

}
