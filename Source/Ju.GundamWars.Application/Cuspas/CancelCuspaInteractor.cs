using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas.Mappers;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Cuspas.Domain.Factories;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;

namespace Ju.GundamWars.Application.Cuspas;

public class CancelCuspaInteractor(
    ICuspaRepository repository,
    CuspaFactory entityFactory,
    CuspaSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelCuspaInteractor> logger)
    : CancelInteractorBase<Cuspa, CuspaSubject, ICuspaRepository, CuspaFactory, CuspaSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelCuspaUseCase
{
}
