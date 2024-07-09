using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Cuspas.Mappers;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Cuspas.Factories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class InsertCuspaInteractor(
    ICuspaRepository repository,
    CuspaFactory entityFactory,
    CuspaSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ICuspaInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertCuspaInteractor> logger)
    : InsertInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaFactory, CuspaSubjectMapper, ICuspaInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
