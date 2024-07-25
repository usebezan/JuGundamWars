using Ju.GundamWars.Client.Commons.Domain.Gateway;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain.Service;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
using Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;

public class CoMobileWebClient(CoMobileWebApiController controller, CoMobileDtoMapper dtoMapper, CoMobileModelMapper modelMapper, ILogger<TagWebClient> logger)
    : ITxnClientGateway<CoMobile>
{
    public Task<CoMobile> InsertAsync(CoMobile model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.InsertAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<CoMobile> UpdateAsync(CoMobile model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.UpdateAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<CoMobile> DeleteAsync(CoMobile model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.DeleteAsync(model.Id);
            return modelMapper.Map(dto, model);
        });
}
