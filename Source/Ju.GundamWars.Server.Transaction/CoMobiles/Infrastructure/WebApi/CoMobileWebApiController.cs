using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Server.CoMobiles.Domain.Gateway;
using Ju.GundamWars.Server.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;

public class CoMobileWebApiController(
    ISelectAllUseCase<CoMobileEntity, ICoMobileRepository> selectAllServerUseCase,
    IInsertUseCase<CoMobileEntity, ICoMobileRepository, InsertCoMobileSanitizer> insertServerUseCase,
    IUpdateUseCase<CoMobileEntity, ICoMobileRepository, UpdateCoMobileSanitizer> updateServerUseCase,
    IDeleteUseCase<long, CoMobileEntity, ICoMobileRepository> deleteServerUseCase,
    CoMobileMapper<CoMobileEntity, CoMobileDto, CoMobileTagMapEntity, CoMobileTagMapDto> dtoMapper,
    CoMobileMapper<CoMobileDto, CoMobileEntity, CoMobileTagMapDto, CoMobileTagMapEntity> entityMapper,
    ILogger<CoMobileWebApiController> logger)
        : TxnControllerBase<CoMobileEntity, CoMobileDto, ICoMobileRepository, InsertCoMobileSanitizer, UpdateCoMobileSanitizer>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
