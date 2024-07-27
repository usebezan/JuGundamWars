using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Pilots.Domain;
using Ju.GundamWars.Server.Pilots.Domain.Gateway;
using Ju.GundamWars.Server.Pilots.Domain.Service;
using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.WebApi;

public class PilotWebApiController(
    ISelectAllUseCase<PilotEntity, IPilotRepository> selectAllServerUseCase,
    IInsertUseCase<PilotEntity, IPilotRepository, PilotSanitizer<PilotEntity>> insertServerUseCase,
    IUpdateUseCase<PilotEntity, IPilotRepository, PilotSanitizer<PilotEntity>> updateServerUseCase,
    IDeleteUseCase<long, PilotEntity, IPilotRepository> deleteServerUseCase,
    PilotServerMapper<PilotEntity, PilotSlotAbilityEntity, PilotTagLinkEntity, PilotDto, PilotSlotAbilityDto, PilotTagLinkDto> dtoMapper,
    PilotServerMapper<PilotDto, PilotSlotAbilityDto, PilotTagLinkDto, PilotEntity, PilotSlotAbilityEntity, PilotTagLinkEntity> entityMapper,
    ILogger<PilotWebApiController> logger)
        : TxnControllerBase<PilotEntity, PilotDto, IPilotRepository, PilotSanitizer<PilotEntity>, PilotSanitizer<PilotEntity>>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
