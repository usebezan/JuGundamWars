using Ju.GundamWars.Client.Commons.Domain.Gateway;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Cuspas.Domain.Service;
using Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Cuspas.Infrastructure.WebClient;

public class CuspaWebClient(CuspaWebApiController controller, CuspaDtoMapper dtoMapper, CuspaModelMapper modelMapper, ILogger<CuspaWebClient> logger)
    : ITxnClientGateway<Cuspa>
{
    public Task<Cuspa> InsertAsync(Cuspa model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.InsertAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Cuspa> UpdateAsync(Cuspa model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.UpdateAsync(dtoMapper.Map(model, new()));
            return modelMapper.Map(dto, model);
        });
    public Task<Cuspa> DeleteAsync(Cuspa model) =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.DeleteAsync(model.Id);
            return modelMapper.Map(dto, model);
        });
}
