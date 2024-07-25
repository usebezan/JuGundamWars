using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Cuspas.Domain;
using Ju.GundamWars.Server.Cuspas.Domain.Gateway;
using Ju.GundamWars.Server.Cuspas.Domain.Service;
using Ju.GundamWars.Share.Cuspas.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;

public class CuspaWebApiController(
    ISelectAllUseCase<CuspaEntity, ICuspaRepository> selectAllServerUseCase,
    IInsertUseCase<CuspaEntity, ICuspaRepository, InsertCuspaServerSanitizer> insertServerUseCase,
    IUpdateUseCase<CuspaEntity, ICuspaRepository, UpdateCuspaServerSanitizer> updateServerUseCase,
    IDeleteUseCase<long, CuspaEntity, ICuspaRepository> deleteServerUseCase,
    CuspaMapper<CuspaEntity, CuspaDto, CuspaTagMapEntity, CuspaTagMapDto> dtoMapper,
    CuspaMapper<CuspaDto, CuspaEntity, CuspaTagMapDto, CuspaTagMapEntity> entityMapper,
    ILogger<CuspaWebApiController> logger)
        : TxnControllerBase<CuspaEntity, CuspaDto, ICuspaRepository, InsertCuspaServerSanitizer, UpdateCuspaServerSanitizer>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
