using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Mappers;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class InsertSupportInteractor(
    ISupportRepository repository,
    SupportFactory entityFactory,
    SupportSubjectMapper subjectMapper,
    MobileSubjectMapper mobileSubjectMapper,
    ISupportInventory inventory,
    IMobileInventory mobileInventory,
    IEnterPresenter presenter,
    ILogger<InsertSupportInteractor> logger)
    : InsertInteractorBase<Support, SupportSubject, ISupportRepository, SupportFactory, SupportSubjectMapper, ISupportInventory>(repository, entityFactory, subjectMapper, mobileSubjectMapper, inventory, mobileInventory, presenter, logger),
        IInsertSupportUseCase
{

    protected override string GetName(SupportSubject subject) => $"Support '{subject.Name}'";

}
