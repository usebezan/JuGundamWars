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
                    // Domain
                    .AddSingleton(typeof(MobileSSkillMapper<,>))
                ;
                // PilotAbilities
                services
                    // Domain
                    .AddSingleton(typeof(PilotAbilityMapper<,>))
                ;
                // PilotSkills
                services
                    // Domain
                    .AddSingleton(typeof(PilotSkillMapper<,>))
                ;
                // Serials
                services
                    // Domain
                    .AddSingleton(typeof(SerialMapper<,>))
                ;
                // Skills
                services
                    // Domain
                    .AddSingleton(typeof(SkillMapper<,>))
                ;
                // SupportBadges
                services
                    // Domain
                    .AddSingleton(typeof(SupportBadgeMapper<,>))
                ;
                // SupportSlots
                services
                    // Domain
                    .AddSingleton(typeof(SupportSlotMapper<,>))
                ;
                // Versionings
                services
                    // Domain
                    .AddSingleton(typeof(VersioningMapper<,>))
                ;
            });
}
