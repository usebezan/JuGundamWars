using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Mobiles.Mappers;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Factories;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Application.Mobiles;

public class CancelMobileInteractor(
    IMobileRepository repository,
    MobileFactory entityFactory,
    MobileSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger<CancelMobileInteractor> logger)
    : CancelInteractorBase<Mobile, MobileSubject, IMobileRepository, MobileFactory, MobileSubjectMapper>(repository, entityFactory, subjectMapper, presenter, logger),
        ICancelMobileUseCase
{
}
