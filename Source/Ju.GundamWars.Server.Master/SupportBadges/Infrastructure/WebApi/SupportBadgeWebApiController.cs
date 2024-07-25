using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.SupportBadges.Domain;
using Ju.GundamWars.Share.SupportBadges.Domain;
using Ju.GundamWars.Share.SupportBadges.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.SupportBadges.Infrastructure.WebApi;

public class SupportBadgeWebApiController(
    ISelectByIdUseCase<SupportBadgeEntity, IMasterRepository<SupportBadgeEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<SupportBadgeEntity, IMasterRepository<SupportBadgeEntity>> selectAllServerUseCase,
    SupportBadgeMapper<SupportBadgeEntity, SupportBadgeDto> dtoMapper,
    ILogger<SupportBadgeWebApiController> logger)
        : MasterControllerBase<SupportBadgeEntity, SupportBadgeDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
