using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas.Mappers;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;

namespace Ju.GundamWars.Application.Cuspas;

public class UpdateCuspaInteractor(
    ICuspaRepository repository,
    CuspaMapper entityMapper,
    CuspaSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateCuspaInteractor> logger)
    : UpdateInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaMapper, CuspaSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateCuspaUseCase
{

    protected override string GetName(CuspaSubject subject) => $"Cuspa '{subject.Name}'";

}
