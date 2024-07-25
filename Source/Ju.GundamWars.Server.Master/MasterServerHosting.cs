using Ju.GundamWars.Server.MobileSSkills.Infrastructure.WebApi;
using Ju.GundamWars.Server.PilotAbilities.Infrastructure.WebApi;
using Ju.GundamWars.Server.PilotSkills.Infrastructure.WebApi;
using Ju.GundamWars.Server.Serials.Infrastructure.WebApi;
using Ju.GundamWars.Server.Skills.Infrastructure.WebApi;
using Ju.GundamWars.Server.SupportBadges.Infrastructure.WebApi;
using Ju.GundamWars.Server.SupportSlots.Infrastructure.WebApi;
using Ju.GundamWars.Server.Versionings.Infrastructure.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Server;

public static class MasterServerHosting
{
    public static IHostBuilder ConfigureMasterServer(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // MobileSSkills
                services
                    // Infrastructure.WebApi
                    .AddSingleton<MobileSSkillWebApiController>()
                ;
                // PilotAbilities
                services
                    // Infrastructure.WebApi
                    .AddSingleton<PilotAbilityWebApiController>()
                ;
                // PilotSkills
                services
                    // Infrastructure.WebApi
                    .AddSingleton<PilotSkillWebApiController>()
                ;
                // Serials
                services
                    // Infrastructure.WebApi
                    .AddSingleton<SerialWebApiController>()
                ;
                // Skills
                services
                    // Infrastructure.WebApi
                    .AddSingleton<SkillWebApiController>()
                ;
                // SupportBadges
                services
                    // Infrastructure.WebApi
                    .AddSingleton<SupportBadgeWebApiController>()
                ;
                // SupportSlots
                services
                    // Infrastructure.WebApi
                    .AddSingleton<SupportSlotWebApiController>()
                ;
                // Versionings
                services
                    // Infrastructure.WebApi
                    .AddSingleton<VersioningWebApiController>()
                ;
            });
}
