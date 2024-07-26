using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Cuspas.Domain;
using Ju.GundamWars.Server.Cuspas.Domain.Gateway;
using Ju.GundamWars.Server.Cuspas.Domain.Service;
using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;

public class CuspaWebApiController(
    ISelectAllUseCase<CuspaEntity, ICuspaRepository> selectAllServerUseCase,
    IInsertUseCase<CuspaEntity, ICuspaRepository, CuspaSanitizer<CuspaEntity>> insertServerUseCase,
    IUpdateUseCase<CuspaEntity, ICuspaRepository, CuspaSanitizer<CuspaEntity>> updateServerUseCase,
    IDeleteUseCase<long, CuspaEntity, ICuspaRepository> deleteServerUseCase,
    CuspaServerMapper<CuspaEntity, CuspaTagLinkEntity, CuspaDto, CuspaTagLinkDto> dtoMapper,
    CuspaServerMapper<CuspaDto, CuspaTagLinkDto, CuspaEntity, CuspaTagLinkEntity> entityMapper,
    ILogger<CuspaWebApiController> logger)
        : TxnControllerBase<CuspaEntity, CuspaDto, ICuspaRepository, CuspaSanitizer<CuspaEntity>, CuspaSanitizer<CuspaEntity>>(
            selectAllServerUseCase,
            insertServerUseCase,
            updateServerUseCase,
            deleteServerUseCase,
            dtoMapper,
            entityMapper,
            logger)
{
}
