using Ju.GundamWars.Server.CoMobiles.Domain.Service;
using Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;
using Ju.GundamWars.Server.Cuspas.Domain.Service;
using Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;
using Ju.GundamWars.Server.Tags.Infrastructure.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Server;

public static class TransactionServerHosting
{
    public static IHostBuilder ConfigureTransactionServer(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // CoMobiles
                services
                    // Domain.Service
                    .AddSingleton(typeof(CoMobileServerMapper<,,,>))
                    // Infrastructure.WebApi
                    .AddSingleton<CoMobileWebApiController>()
                ;

                // Cuspas
                services
                    // Domain.Service
                    .AddSingleton(typeof(CuspaServerMapper<,,,>))
                    // Infrastructure.WebApi
                    .AddSingleton<CuspaWebApiController>()
                ;

                // Tags
                services
                    // Infrastructure.WebApi
                    .AddSingleton<TagWebApiController>()
                ;
            });
}
