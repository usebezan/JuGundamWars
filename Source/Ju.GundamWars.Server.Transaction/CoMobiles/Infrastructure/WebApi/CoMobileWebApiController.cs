using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Server.CoMobiles.Domain.Gateway;
using Ju.GundamWars.Server.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;

public class CoMobileWebApiController(
    IInsertUseCase<CoMobileEntity, ICoMobileRepository, InsertCoMobileSanitizer<CoMobileEntity>> insertCoMobileServerUseCase,
    IUpdateUseCase<CoMobileEntity, ICoMobileRepository, UpdateCoMobileSanitizer<CoMobileEntity>> updateCoMobileServerUseCase,
    IDeleteUseCase<long, CoMobileEntity, ICoMobileRepository> deleteCoMobileServerUseCase,
    CoMobileMapper<CoMobileEntity, CoMobileDto, CoMobileTagMapEntity, CoMobileTagMapDto> coMobileDtoMapper,
    CoMobileMapper<CoMobileDto, CoMobileEntity, CoMobileTagMapDto, CoMobileTagMapEntity> coMobileEntityMapper,
    ILogger<CoMobileWebApiController> logger) :
        ControllerBase<CoMobileEntity, CoMobileDto, ICoMobileRepository, InsertCoMobileSanitizer<CoMobileEntity>, UpdateCoMobileSanitizer<CoMobileEntity>>(
            insertCoMobileServerUseCase,
            updateCoMobileServerUseCase,
            deleteCoMobileServerUseCase,
            coMobileDtoMapper,
            coMobileEntityMapper,
            logger)
{
}
