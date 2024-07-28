using Ju.GundamWars.Client.Commons.Domain.Gateway;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Client.Supports.Domain.Service;
using Ju.GundamWars.Server.Supports.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Supports.Infrastructure.WebClient;

public class SupportWebClient(SupportWebApiController controller, SupportDtoMapper dtoMapper, SupportModelMapper modelMapper, ILogger<SupportWebClient> logger)
    : ITxnClientGateway<Support>
{
    public Task<Support> InsertAsync(Support model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.InsertAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Support> UpdateAsync(Support model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.UpdateAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Support> DeleteAsync(Support model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.DeleteAsync(model.Id);
            return modelMapper.Map(dto, model);
        });
}
