using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.Application;
using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.UseCase.InputPort;
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
                    .AddSingleton(typeof(IDeletePresentableUseCase<,,,>), typeof(DeletePresentableInteractor<,,,>))
                    .AddSingleton(typeof(IInsertPresentableUseCase<,,>), typeof(InsertPresentableInteractor<,,>))
                    .AddSingleton(typeof(IInsertPresentableUseCase<,,,>), typeof(InsertPresentableInteractor<,,,>))
                    .AddSingleton(typeof(IInsertPresentableUseCase<,,,,>), typeof(InsertPresentableInteractor<,,,,>))
                    .AddSingleton(typeof(IUpdatePresentableUseCase<,,>), typeof(UpdatePresentableInteractor<,,>))
                    .AddSingleton(typeof(IUpdatePresentableUseCase<,,,>), typeof(UpdatePresentableInteractor<,,,>))
                    .AddSingleton(typeof(IUpdatePresentableUseCase<,,,,>), typeof(UpdatePresentableInteractor<,,,,>))
                    // Infrastructure.WebClient
                    .AddSingleton<HttpClient>()
                ;

                // CoMobiles
                services
                    // Infrastructure.WebClient
                    .AddSingleton<CoMobileWebClient>()
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
