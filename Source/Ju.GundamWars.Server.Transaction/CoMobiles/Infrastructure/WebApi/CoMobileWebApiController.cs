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
    IInsertUseCase<CoMobileEntity, ICoMobileRepository, CoMobileServerSanitizer> insertServerUseCase,
    IUpdateUseCase<CoMobileEntity, ICoMobileRepository, CoMobileServerSanitizer> updateServerUseCase,
    IDeleteUseCase<long, CoMobileEntity, ICoMobileRepository> deleteServerUseCase,
    CoMobileServerMapper<CoMobileEntity, CoMobileTagLinkEntity, CoMobileDto, CoMobileTagLinkDto> dtoMapper,
    CoMobileServerMapper<CoMobileDto, CoMobileTagLinkDto, CoMobileEntity, CoMobileTagLinkEntity> entityMapper,
    ILogger<CoMobileWebApiController> logger)
        : TxnControllerBase<CoMobileEntity, CoMobileDto, ICoMobileRepository, CoMobileServerSanitizer, CoMobileServerSanitizer>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
    //public new Task<List<CoMobileDto>> SelectAllAsync() =>
    //    this.Execute(logger, async () =>
    //    {
    //        var entities = await selectAllServerUseCase.HandleAsync();
    //        return entities.Select(e => dtoMapper.Map(e, new())).ToList();
    //    });
}
