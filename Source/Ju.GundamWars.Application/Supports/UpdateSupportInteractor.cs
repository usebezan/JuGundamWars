using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Domain.Supports.Mappers;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Application.Supports;

public class UpdateSupportInteractor(
    ISupportRepository repository,
    SupportMapper entityMapper,
    SupportSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<UpdateSupportInteractor> logger)
    : UpdateInteractorBase<Support, SupportSubject, ISupportRepository, SupportMapper, SupportSubjectMapper>(repository, entityMapper, subjectMapper, mobileSubjectMapper, mobileInventory, presenter, logger),
        IUpdateSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
