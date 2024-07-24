using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.WebApi;

public abstract class ControllerBase<TEntity, TDto, TGateway, TInsertSanitizer, TUpdateSanitizer>(
    IInsertServerUseCase<TEntity, TGateway, TInsertSanitizer> insertServerUseCase,
    IUpdateServerUseCase<TEntity, TGateway, TUpdateSanitizer> updateServerUseCase,
    IDeleteByIdServerUseCase<TEntity, TGateway> deleteServerUseCase,
    IMapper<TEntity, TDto> TDtoMapper,
    IMapper<TDto, TEntity> TEntityMapper,
    ILogger logger) : IGw
    where TEntity : class, IIdentify, new()
    where TDto : IIdentify, new()
    where TGateway : ITxnGateway<TEntity>
    where TInsertSanitizer : IInsertSanitizer<TEntity>
    where TUpdateSanitizer : IUpdateSanitizer<TEntity>
{
    public Task<TDto> InsertAsync(TDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await insertServerUseCase.HandleAsync(TEntityMapper.Map(dto, new()));
            return TDtoMapper.Map(entity, new());
        });
    public Task<TDto> UpdateAsync(TDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await updateServerUseCase.HandleAsync(TEntityMapper.Map(dto, new()));
            return TDtoMapper.Map(entity, new());
        });
    public Task<TDto> DeleteAsync(TDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await deleteServerUseCase.HandleAsync(dto.Id);
            return TDtoMapper.Map(entity, new());
        });
}
