using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Cuspas;

public class DeleteCuspaInteractor(
    ICuspaRepository repository,
    MobileSubjectMapper mobileSubjectMapper,
    ICuspaInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<DeleteCuspaInteractor> logger)
    : DeleteInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, ICuspaInventory>(repository, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IDeleteCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
