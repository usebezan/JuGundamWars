using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Cuspas.Domain;
using Ju.GundamWars.Server.Cuspas.Domain.Gateway;
using Ju.GundamWars.Server.Cuspas.Domain.Service;
using Ju.GundamWars.Share.Cuspas.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;

public class CuspaWebApiController(
    IInsertUseCase<CuspaEntity, ICuspaRepository, InsertCuspaServerSanitizer> insertCuspaServerUseCase,
    IUpdateUseCase<CuspaEntity, ICuspaRepository, UpdateCuspaServerSanitizer> updateCuspaServerUseCase,
    IDeleteUseCase<long, CuspaEntity, ICuspaRepository> deleteCuspaServerUseCase,
    CuspaMapper<CuspaEntity, CuspaDto, CuspaTagMapEntity, CuspaTagMapDto> coMobileDtoMapper,
    CuspaMapper<CuspaDto, CuspaEntity, CuspaTagMapDto, CuspaTagMapEntity> coMobileEntityMapper,
    ILogger<CuspaWebApiController> logger)
        : ControllerBase<CuspaEntity, CuspaDto, ICuspaRepository, InsertCuspaServerSanitizer, UpdateCuspaServerSanitizer>(
            insertCuspaServerUseCase,
            updateCuspaServerUseCase,
            deleteCuspaServerUseCase,
            coMobileDtoMapper,
            coMobileEntityMapper,
            logger)
{
}
