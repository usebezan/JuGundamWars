using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Mappers;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Factories;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Supports;

public class CancelSupportInteractor(
    ISupportRepository repository,
    SupportFactory entityFactory,
    SupportSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelSupportInteractor> logger)
    : CancelInteractorBase<Support, SupportSubject, ISupportRepository, SupportFactory, SupportSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelSupportUseCase
{
}
