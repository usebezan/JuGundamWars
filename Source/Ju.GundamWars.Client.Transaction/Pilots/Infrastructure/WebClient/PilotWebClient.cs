using Ju.GundamWars.Client.Commons.Domain.Gateway;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.Pilots.Domain.Service;
using Ju.GundamWars.Server.Pilots.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Pilots.Infrastructure.WebClient;

public class PilotWebClient(PilotWebApiController controller, PilotDtoMapper dtoMapper, PilotModelMapper modelMapper, ILogger<PilotWebClient> logger)
    : ITxnClientGateway<Pilot>
{
    public Task<Pilot> InsertAsync(Pilot model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.InsertAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Pilot> UpdateAsync(Pilot model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.UpdateAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Pilot> DeleteAsync(Pilot model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.DeleteAsync(model.Id);
            return modelMapper.Map(dto, model);
        });
}
