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
    IInsertUseCase<CoMobileEntity, ICoMobileRepository, InsertCoMobileSanitizer> insertCoMobileServerUseCase,
    IUpdateUseCase<CoMobileEntity, ICoMobileRepository, UpdateCoMobileSanitizer> updateCoMobileServerUseCase,
    IDeleteUseCase<long, CoMobileEntity, ICoMobileRepository> deleteCoMobileServerUseCase,
    CoMobileMapper<CoMobileEntity, CoMobileDto, CoMobileTagMapEntity, CoMobileTagMapDto> coMobileDtoMapper,
    CoMobileMapper<CoMobileDto, CoMobileEntity, CoMobileTagMapDto, CoMobileTagMapEntity> coMobileEntityMapper,
    ILogger<CoMobileWebApiController> logger)
        : TxnControllerBase<CoMobileEntity, CoMobileDto, ICoMobileRepository, InsertCoMobileSanitizer, UpdateCoMobileSanitizer>(
            selectAllServerUseCase,
            insertCoMobileServerUseCase,
            updateCoMobileServerUseCase,
            deleteCoMobileServerUseCase,
            coMobileDtoMapper,
            coMobileEntityMapper,
            logger)
{
}
