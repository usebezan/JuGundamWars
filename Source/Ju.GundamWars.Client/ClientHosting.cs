using Ju.GundamWars.Client.Commons.Application;
using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.Application;
using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class ClientHosting
{
    public static IHostBuilder ConfigureClient(this IHostBuilder self) =>
        self
            .ConfigureConstClient()
            .ConfigureMasterClient()
            .ConfigureTransactionClient()
            .ConfigureServices((context, services) =>
            {
                // Commons
                services
                    // Application
                    .AddSingleton(typeof(IDeleteByIdClientUseCase<,,>), typeof(DeleteByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IInsertClientUseCase<,,,,>), typeof(InsertClientInteractor<,,,,>))
                    .AddSingleton(typeof(ISelectByIdClientUseCase<,,>), typeof(SelectByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IUpdateClientUseCase<,,,>), typeof(UpdateClientInteractor<,,,>))
                    .AddSingleton(typeof(IUpdateClientUseCase<,,,,>), typeof(UpdateClientInteractor<,,,,>))
                    // Infrastructure.WebClient
                    .AddSingleton<HttpClient>()
                ;

                // Systems
                services
                    // Application
                    .AddSingleton<ILoadAllClientUseCase, LoadAllClientInteractor>()
                    // Infrastructure.WebClient
                    .AddSingleton<SystemWebClient>()
                ;

                // Tags
                services
                    // Infrastructure.WebClient
                    .AddSingleton<TagWebClient>()
                ;
            });
}
