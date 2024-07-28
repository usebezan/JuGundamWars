using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Supports.Domain;
using Ju.GundamWars.Server.Supports.Domain.Gateway;
using Ju.GundamWars.Server.Supports.Domain.Service;
using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.Supports.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Supports.Infrastructure.WebApi;

public class SupportWebApiController(
    ISelectAllUseCase<SupportEntity, ISupportRepository> selectAllServerUseCase,
    IInsertUseCase<SupportEntity, ISupportRepository, SupportSanitizer<SupportEntity>> insertServerUseCase,
    IUpdateUseCase<SupportEntity, ISupportRepository, SupportSanitizer<SupportEntity>> updateServerUseCase,
    IDeleteUseCase<long, SupportEntity, ISupportRepository> deleteServerUseCase,
    SupportServerMapper<SupportEntity, SupportLimitedSerialLinkEntity, SupportSlotBadgeEntity, SupportTagLinkEntity, SupportDto, SupportLimitedSerialLinkDto, SupportSlotBadgeDto, SupportTagLinkDto> dtoMapper,
    SupportServerMapper<SupportDto, SupportLimitedSerialLinkDto, SupportSlotBadgeDto, SupportTagLinkDto, SupportEntity, SupportLimitedSerialLinkEntity, SupportSlotBadgeEntity, SupportTagLinkEntity> entityMapper,
    ILogger<SupportWebApiController> logger)
        : TxnControllerBase<SupportEntity, SupportDto, ISupportRepository, SupportSanitizer<SupportEntity>, SupportSanitizer<SupportEntity>>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
