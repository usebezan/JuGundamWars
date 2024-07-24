using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;

public class CoMobileWebApiController(
    IInsertServerUseCase<CoMobileEntity, ICoMobileRepository, InsertCoMobileSanitizer<CoMobileEntity>> insertCoMobileServerUseCase,
    IUpdateServerUseCase<CoMobileEntity, ICoMobileRepository, UpdateCoMobileSanitizer<CoMobileEntity>> updateCoMobileServerUseCase,
    IDeleteByIdServerUseCase<CoMobileEntity, ICoMobileRepository> deleteCoMobileServerUseCase,
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
