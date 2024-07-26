using Ju.GundamWars.Share.MobileSSkills.Domain.Service;
using Ju.GundamWars.Share.PilotAbilities.Domain.Service;
using Ju.GundamWars.Share.PilotSkills.Domain.Service;
using Ju.GundamWars.Share.Serials.Domain.Service;
using Ju.GundamWars.Share.Skills.Domain.Service;
using Ju.GundamWars.Share.SupportBadges.Domain.Service;
using Ju.GundamWars.Share.SupportSlots.Domain.Service;
using Ju.GundamWars.Share.Versionings.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Share;

public static class MasterShareHosting
{
    public static IHostBuilder ConfigureMasterShare(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // MobileSSkills
                services
                    // Domain.Service
                    .AddSingleton(typeof(MobileSSkillMapper<,>))
                ;
                // PilotAbilities
                services
                    // Domain.Service
                    .AddSingleton(typeof(PilotAbilityMapper<,>))
                ;
                // PilotSkills
                services
                    // Domain.Service
                    .AddSingleton(typeof(PilotSkillMapper<,>))
                ;
                // Serials
                services
                    // Domain.Service
                    .AddSingleton(typeof(SerialMapper<,>))
                ;
                // Skills
                services
                    // Domain.Service
                    .AddSingleton(typeof(SkillMapper<,>))
                ;
                // SupportBadges
                services
                    // Domain.Service
                    .AddSingleton(typeof(SupportBadgeMapper<,>))
                ;
                // SupportSlots
                services
                    // Domain.Service
                    .AddSingleton(typeof(SupportSlotMapper<,>))
                ;
                // Versionings
                services
                    // Domain.Service
                    .AddSingleton(typeof(VersioningMapper<,>))
                ;
            });
}
