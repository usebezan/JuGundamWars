using Ju.GundamWars.Client.Commons.Application;
using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.Application;
using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class ClientCoreHosting
{
    public static IHostBuilder ConfigureClientCore(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Commons
                services
                    // Application
                    .AddSingleton(typeof(IDeleteByIdClientUseCase<,,>), typeof(DeleteByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IInsertClientUseCase<,,,,>), typeof(InsertClientInteractor<,,,,>))
                    .AddSingleton(typeof(ISelectByIdClientUseCase<,,>), typeof(SelectByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IUpdateClientUseCase<,,,,>), typeof(UpdateClientInteractor<,,,,>))
                    // Infrastructure.WebClient
                    .AddSingleton<HttpClient>()
                ;

                // Systems
                services
                    // Application
                    .AddSingleton<IPutAllTagsClientUseCase, LoadAllClientInteractor>()
                    // Infrastructure.WebClient
                    .AddSingleton<SystemWebClient>()
                ;
            });
}
