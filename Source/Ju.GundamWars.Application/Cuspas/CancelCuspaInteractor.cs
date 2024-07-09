using Ju.GundamWars.Application.Cuspas.Repositories;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Cuspas.Mappers;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Cuspas.Factories;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

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
