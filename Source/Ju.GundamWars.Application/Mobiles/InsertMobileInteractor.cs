using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Entities;
using Ju.GundamWars.Mobiles.Domain.Factories;

namespace Ju.GundamWars.Application.Mobiles;

public class InsertMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectMapper subjectMapper,
    IMobileInventory inventory,
    IEnterPresenter presenter,
    ILogger<InsertMobileInteractor> logger)
    : InsertInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectMapper, IMobileInventory>(repository, entityFactory, subjectMapper, subjectMapper, inventory, inventory, presenter, logger),
        IInsertMobileUseCase
{

    protected override string GetName(MobileSubject subject) => $"Mobile '{subject.Name}'";

}
