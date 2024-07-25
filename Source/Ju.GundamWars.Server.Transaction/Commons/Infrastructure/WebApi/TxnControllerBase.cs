using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.WebApi;

public abstract class TxnControllerBase<TEntity, TDto, TGateway, TInsertSanitizer, TUpdateSanitizer>(
    ISelectAllUseCase<TEntity, TGateway> selectAllServerUseCase,
    IInsertUseCase<TEntity, TGateway, TInsertSanitizer> insertServerUseCase,
    IUpdateUseCase<TEntity, TGateway, TUpdateSanitizer> updateServerUseCase,
    IDeleteUseCase<long, TEntity, TGateway> deleteServerUseCase,
    IMapper<TEntity, TDto> dtoMapper,
    IMapper<TDto, TEntity> entityMapper,
    ILogger logger) : IGw
    where TEntity : IIdentifiable, new()
    where TDto : IIdentifiable, new()
    where TGateway : ITxnRepository<TEntity>
    where TInsertSanitizer : IInsertSanitizer<TEntity>
    where TUpdateSanitizer : IUpdateSanitizer<TEntity>
{
    public Task<List<TDto>> SelectAllAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllServerUseCase.HandleAsync();
            return entities.Select(e => dtoMapper.Map(e, new())).ToList();
        });
    public Task<TDto> InsertAsync(TDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await insertServerUseCase.HandleAsync(entityMapper.Map(dto, new()));
            return dtoMapper.Map(entity, new());
        });
    public Task<TDto> UpdateAsync(TDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await updateServerUseCase.HandleAsync(entityMapper.Map(dto, new()));
            return dtoMapper.Map(entity, new());
        });
    public Task<TDto> DeleteAsync(long id) =>
        this.Execute(logger, async () =>
        {
            var entity = await deleteServerUseCase.HandleAsync(id);
            return dtoMapper.Map(entity, new());
        });
}
