using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Server.Systems.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Infrastructure.WebClient;

public class SystemWebClient(
    SystemWebApiController httpClient,
    PilotAbilityPrimitiveMapper<PilotAbilityDto, PilotAbility> pilotAbilityModelMapper,
    SerialPrimitiveMapper<SerialDto, Serial> serialModelMapper,
    SkillPrimitiveMapper<SkillDto, Skill> skillModelMapper,
    SupportBadgePrimitiveMapper<SupportBadgeDto, SupportBadge> supportBadgeModelMapper,
    SupportSlotPrimitiveMapper<SupportSlotDto, SupportSlot> supportSlotModelMapper,
    ILogger<SystemWebClient> logger
    ) : IGw
{
    public Task<List<PilotAbility>> SelectAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await httpClient.SelectAllPilotAbilitiesAsync();
            return entities.Select(e => pilotAbilityModelMapper.Map(e, new())).ToList();
        });
    public Task<List<Serial>> SelectAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await httpClient.SelectAllSerialsAsync();
            return entities.Select(e => serialModelMapper.Map(e, new())).ToList();
        });
    public Task<List<Skill>> SelectAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await httpClient.SelectAllSkillsAsync();
            return entities.Select(e => skillModelMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportBadge>> SelectAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await httpClient.SelectAllSupportBadgesAsync();
            return entities.Select(e => supportBadgeModelMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportSlot>> SelectAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await httpClient.SelectAllSupportSlotsAsync();
            return entities.Select(e => supportSlotModelMapper.Map(e, new())).ToList();
        });
}
