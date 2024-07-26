using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.WebApi;

public class MasterController<TEntity, TDto, TMapper>(
    ISelectByIdUseCase<TEntity, IMasterRepository<TEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<TEntity, IMasterRepository<TEntity>> selectAllServerUseCase,
    TMapper dtoMapper,
    ILogger<MasterController<TEntity, TDto, TMapper>> logger) : IGw
    where TEntity : IIdentifiable, IOrderable, new()
    where TDto : IIdentifiable, IOrderable, new()
    where TMapper : IMapper<TEntity, TDto>
{
    public Task<TDto?> SelectByIdAsync(long id) =>
        this.Execute(logger, async () =>
        {
            var entity = await selectByIdServerUseCase.HandleAsync(id);
            return entity == null ? default : dtoMapper.Map(entity, new());
        });
    public Task<List<TDto>> SelectAllAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllServerUseCase.HandleAsync();
            return entities.Select(e => dtoMapper.Map(e, new())).ToList();
        });
}
