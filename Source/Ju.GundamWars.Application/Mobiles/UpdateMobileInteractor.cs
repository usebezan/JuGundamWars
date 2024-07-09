using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Entities;

namespace Ju.GundamWars.Application.Mobiles;

public class UpdateMobileInteractor(
    IMobileRepository repository,
    MobileMapper entityMapper,
    MobileSubjectMapper subjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateMobileInteractor> logger)
    : UpdateInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileMapper, MobileSubjectMapper>(repository, entityMapper, subjectMapper, subjectMapper, mobileInventory, presenter, logger),
        IUpdateMobileUseCase
{

    protected override string GetName(MobileSubject subject) => $"Mobile '{subject.Name}'";

}
