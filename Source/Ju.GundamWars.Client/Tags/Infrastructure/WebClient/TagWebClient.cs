using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Tags.Infrastructure.WebApi;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Tags.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Tags.Infrastructure.WebClient;

public class TagWebClient(TagWebApiController controller, TagMapper<Tag, TagDto> dtoMapper, TagMapper<TagDto, Tag> modelMapper, ILogger<TagWebClient> logger)
    : IGw, IUpdateGateway<Tag>
{
    public Task<Tag> UpdateAsync(Tag model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.UpdateAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
}
