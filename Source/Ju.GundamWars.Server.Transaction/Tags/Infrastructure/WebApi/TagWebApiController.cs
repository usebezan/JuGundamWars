using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Tags.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Tags.Infrastructure.WebApi;

public class TagWebApiController(
    ISelectAllUseCase<TagEntity, ITxnRepository<TagEntity>> selectAllServerUseCase,
    IUpdateUseCase<TagEntity, ITxnRepository<TagEntity>, UpdateTagSanitizer<TagEntity>> updateServerUseCase,
    TagMapper<TagEntity, TagDto> dtoMapper,
    TagMapper<TagDto, TagEntity> entityMapper,
    ILogger<TagWebApiController> logger) : IGw
{
    public Task<List<TagDto>> SelectAllAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllServerUseCase.HandleAsync();
            return entities.Select(e => dtoMapper.Map(e, new())).ToList();
        });
    public Task<TagDto> UpdateAsync(TagDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await updateServerUseCase.HandleAsync(entityMapper.Map(dto, new()));
            return dtoMapper.Map(entity, new());
        });
}
