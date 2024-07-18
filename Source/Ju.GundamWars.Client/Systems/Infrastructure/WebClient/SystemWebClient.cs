using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Server.Systems.Infrastructure.WebApi;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Infrastructure.WebClient;

public class SystemWebClient(
    HttpClient httpClient,
    SystemWebApiController controller,
    MobileSSkillModelMapper mobileSSkillModelMapper,
    PilotAbilityPrimitiveMapper<PilotAbilityDto, PilotAbility> pilotAbilityModelMapper,
    PilotSkillModelMapper pilotSkillModelMapper,
    SerialPrimitiveMapper<SerialDto, Serial> serialModelMapper,
    SkillPrimitiveMapper<SkillDto, Skill> skillModelMapper,
    SupportBadgePrimitiveMapper<SupportBadgeDto, SupportBadge> supportBadgeModelMapper,
    SupportSlotPrimitiveMapper<SupportSlotDto, SupportSlot> supportSlotModelMapper,
    ILogger<SystemWebClient> logger
    ) : IGw
{
    public Task<List<MobileSSkill>> SelectAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllMobileSSkillsAsync();
            return dtos.Select(d => mobileSSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotAbility>> SelectAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllPilotAbilitiesAsync();
            return dtos.Select(d => pilotAbilityModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotSkill>> SelectAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllPilotSkillsAsync();
            return dtos.Select(d => pilotSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Serial>> SelectAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSerialsAsync();
            return dtos.Select(d => serialModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Skill>> SelectAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSkillsAsync();
            return dtos.Select(d => skillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportBadge>> SelectAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSupportBadgesAsync();
            return dtos.Select(d => supportBadgeModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportSlot>> SelectAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSupportSlotsAsync();
            return dtos.Select(d => supportSlotModelMapper.Map(d, new())).ToList();
        });
    public Task<string> SelectVersioningByIdAsync() =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.SelectVersioningByIdAsync();
            return dto.Version;
        });
}
