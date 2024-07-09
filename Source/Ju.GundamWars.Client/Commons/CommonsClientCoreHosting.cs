using Ju.GundamWars.Client.Commons.Application;
using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client.Commons;

public static class CommonsClientCoreHosting
{
    public static IHostBuilder ConfigureCommonsClientCore(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // Application
                services
                    .AddSingleton(typeof(IDeleteByIdClientUseCase<,,>), typeof(DeleteByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IInsertClientUseCase<,,,,>), typeof(InsertClientInteractor<,,,,>))
                    .AddSingleton(typeof(ISelectByIdClientUseCase<,,>), typeof(SelectByIdClientInteractor<,,>))
                    .AddSingleton(typeof(IUpdateClientUseCase<,,,,>), typeof(UpdateClientInteractor<,,,,>))
                ;
            });
}
