using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Tags.Infrastructure.WebApi;

public class TagWebApiController(
    IUpdateServerUseCase<TagEntity, ITxnGateway<TagEntity>, UpdateTagSanitizer> updateTagServerUseCase,
    TagPrimitiveMapper<TagEntity, TagDto> tagDtoMapper,
    TagPrimitiveMapper<TagDto, TagEntity> tagEntityMapper,
    ILogger<TagWebApiController> logger) : IGw
{
    public Task<TagDto> UpdateTagAsync(TagDto dto) =>
        this.Execute(logger, async () =>
        {
            var entity = await updateTagServerUseCase.HandleAsync(tagEntityMapper.Map(dto, new()));
            return tagDtoMapper.Map(entity, new());
        });
}
