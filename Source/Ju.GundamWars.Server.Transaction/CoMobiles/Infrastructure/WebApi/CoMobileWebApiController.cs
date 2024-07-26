using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Server.CoMobiles.Domain.Gateway;
using Ju.GundamWars.Server.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;

public class CoMobileWebApiController(
    ISelectAllUseCase<CoMobileEntity, ICoMobileRepository> selectAllServerUseCase,
    IInsertUseCase<CoMobileEntity, ICoMobileRepository, CoMobileSanitizer<CoMobileEntity>> insertServerUseCase,
    IUpdateUseCase<CoMobileEntity, ICoMobileRepository, CoMobileSanitizer<CoMobileEntity>> updateServerUseCase,
    IDeleteUseCase<long, CoMobileEntity, ICoMobileRepository> deleteServerUseCase,
    CoMobileServerMapper<CoMobileEntity, CoMobileTagLinkEntity, CoMobileDto, CoMobileTagLinkDto> dtoMapper,
    CoMobileServerMapper<CoMobileDto, CoMobileTagLinkDto, CoMobileEntity, CoMobileTagLinkEntity> entityMapper,
    ILogger<CoMobileWebApiController> logger)
        : TxnControllerBase<CoMobileEntity, CoMobileDto, ICoMobileRepository, CoMobileSanitizer<CoMobileEntity>, CoMobileSanitizer<CoMobileEntity>>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
