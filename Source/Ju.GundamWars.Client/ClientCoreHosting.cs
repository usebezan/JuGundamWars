using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
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
                ;

                // Systems
                services
                    // Application
                    .AddSingleton<ILoadAllClientUseCase, LoadAllClientInteractor>()
                    // Domain
                    .AddSingleton<MobileSSkillInventory>()
                    .AddSingleton<PilotAbilityInventory>()
                    .AddSingleton<SerialInventory>()
                    .AddSingleton<SkillInventory>()
                    .AddSingleton<SupportBadgeInventory>()
                    .AddSingleton<SupportSlotInventory>()

                    .AddSingleton<MobileSSkillModelMapper>()
                    // Infrastructure.WebClient
                    .AddSingleton<SystemWebClient>()
                ;
            });
}
