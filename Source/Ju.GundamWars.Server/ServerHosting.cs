using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.CoMobiles.Domain.Gateway;
using Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;
using Ju.GundamWars.Server.Cuspas.Domain.Gateway;
using Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;
using Ju.GundamWars.Server.Pilots.Domain.Gateway;
using Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;
using Ju.GundamWars.Server.Supports.Domain.Gateway;
using Ju.GundamWars.Server.Supports.Infrastructure.Persistence;
using Ju.GundamWars.Share;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Server;

public static class ServerHosting
{
    public static IHostBuilder ConfigureServer(this IHostBuilder self) =>
        self
            .ConfigureMasterShare()
            .ConfigureMasterServer()
            .ConfigureTransactionShare()
            .ConfigureTransactionServer()
            .ConfigureServices((context, services) =>
            {
                // Commons
                services
                    // Application
                    .AddSingleton(typeof(IDeleteUseCase<,,>), typeof(DeleteInteractor<,,>))
                    .AddSingleton(typeof(IInsertUseCase<,>), typeof(InsertInteractor<,>))
                    .AddSingleton(typeof(IInsertUseCase<,,>), typeof(InsertInteractor<,,>))
                    .AddSingleton(typeof(IInsertUseCase<,,,>), typeof(InsertInteractor<,,,>))
                    .AddSingleton(typeof(ISelectAllUseCase<,>), typeof(SelectAllInteractor<,>))
                    .AddSingleton(typeof(ISelectByIdUseCase<,>), typeof(SelectByIdInteractor<,>))
                    .AddSingleton(typeof(IUpdateUseCase<,>), typeof(UpdateInteractor<,>))
                    .AddSingleton(typeof(IUpdateUseCase<,,>), typeof(UpdateInteractor<,,>))
                    .AddSingleton(typeof(IUpdateUseCase<,,,>), typeof(UpdateInteractor<,,,>))
                    // Infrastructure.Persistence
                    .AddSingleton(typeof(IMasterRepository<>), typeof(MasterRepository<>))
                    .AddSingleton(typeof(ITxnRepository<>), typeof(TxnRepository<>))
                ;

                // CoMobiles
                services
                    // Infrastructure.Persistence
                    .AddSingleton<ICoMobileRepository, CoMobileRepository>()
                ;

                // Cuspas
                services
                    // Infrastructure.Persistence
                    .AddSingleton<ICuspaRepository, CuspaRepository>()
                ;

                // Pilots
                services
                    // Infrastructure.Persistence
                    .AddSingleton<IPilotRepository, PilotRepository>()
                ;

                // Supports
                services
                    // Infrastructure.Persistence
                    .AddSingleton<ISupportRepository, SupportRepository>()
                ;
            });
}
