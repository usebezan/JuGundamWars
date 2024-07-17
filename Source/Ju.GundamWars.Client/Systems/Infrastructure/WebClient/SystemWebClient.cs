using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.Server.Systems.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Infrastructure.WebClient;

public class SystemWebClient(
    SystemWebApiController httpClient,
    PilotAbilityPrimitiveMapper<PilotAbilityDto, PilotAbility> pilotAbilityModelMapper,
    SerialPrimitiveMapper<SerialDto, Serial> serialModelMapper,
    SkillPrimitiveMapper<SkillDto, Skill> skillModelMapper,
    SupportBadgePrimitiveMapper<SupportBadgeDto, SupportBadge> supportBadgeModelMapper,
    ILogger<SystemWebClient> logger
    ) : IGw
{
    public Task<DataModels> LoadAllAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await httpClient.LoadAllAsync();
            var models = new DataModels
            {
                PilotAbilities = dtos.PilotAbilities.Select(d => pilotAbilityModelMapper.Map(d, new())).ToList(),
                Serials = dtos.Serials.Select(d => serialModelMapper.Map(d, new())).ToList(),
                Skills = dtos.Skills.Select(d => skillModelMapper.Map(d, new())).ToList(),
                SupportBadges = dtos.SupportBadges.Select(d => supportBadgeModelMapper.Map(d, new())).ToList(),
            };
            return models;
        });
}
