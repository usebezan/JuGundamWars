using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.MobileSSkills.Domain.Service;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain.Service;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ju.GundamWars.Client;

public static class MasterClientHosting
{
    public static IHostBuilder ConfigureMasterClient(this IHostBuilder self) =>
        self
            .ConfigureServices((context, services) =>
            {
                // MobileSSkills
                services
                    // Domain
                    .AddSingleton<MobileSSkillInventory>()
                    // Domain.Service
                    .AddSingleton<MobileSSkillModelMapper>()
                ;
                // PilotAbilities
                services
                    // Domain
                    .AddSingleton<PilotAbilityInventory>()
                ;
                // PilotSkills
                services
                    // Domain
                    .AddSingleton<PilotSkillInventory>()
                    // Domain.Service
                    .AddSingleton<PilotSkillModelMapper>()
                ;
                // Serials
                services
                    // Domain
                    .AddSingleton<SerialInventory>()
                ;
                // Skills
                services
                    // Domain
                    .AddSingleton<SkillInventory>()
                ;
                // SupportBadges
                services
                    // Domain
                    .AddSingleton<SupportBadgeInventory>()
                ;
                // SupportSlots
                services
                    // Domain
                    .AddSingleton<SupportSlotInventory>()
                ;
            });
}
