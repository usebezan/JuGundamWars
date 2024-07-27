using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Domain.Service;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Cuspas.Domain.Service;
using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.MobileSSkills.Domain.Service;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.Pilots.Domain.Service;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain.Service;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.CoMobiles.Infrastructure.WebApi;
using Ju.GundamWars.Server.Cuspas.Infrastructure.WebApi;
using Ju.GundamWars.Server.MobileSSkills.Domain;
using Ju.GundamWars.Server.PilotAbilities.Domain;
using Ju.GundamWars.Server.Pilots.Infrastructure.WebApi;
using Ju.GundamWars.Server.PilotSkills.Domain;
using Ju.GundamWars.Server.Serials.Domain;
using Ju.GundamWars.Server.Skills.Domain;
using Ju.GundamWars.Server.SupportBadges.Domain;
using Ju.GundamWars.Server.SupportSlots.Domain;
using Ju.GundamWars.Server.Tags.Infrastructure.WebApi;
using Ju.GundamWars.Server.Versionings.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain.Service;
using Ju.GundamWars.Share.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain.Service;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain.Service;
using Ju.GundamWars.Share.Serials.Domain;
using Ju.GundamWars.Share.Serials.Domain.Service;
using Ju.GundamWars.Share.Skills.Domain;
using Ju.GundamWars.Share.Skills.Domain.Service;
using Ju.GundamWars.Share.SupportBadges.Domain;
using Ju.GundamWars.Share.SupportBadges.Domain.Service;
using Ju.GundamWars.Share.SupportSlots.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain.Service;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Tags.Domain.Service;
using Ju.GundamWars.Share.Versionings.Domain;
using Ju.GundamWars.Share.Versionings.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Infrastructure.WebClient;

public class SystemWebClient(
    MasterController<MobileSSkillEntity, MobileSSkillDto, MobileSSkillMapper<MobileSSkillEntity, MobileSSkillDto>> mobileSSkillWebApiController,
    MobileSSkillModelMapper mobileSSkillModelMapper,

    MasterController<PilotAbilityEntity, PilotAbilityDto, PilotAbilityMapper<PilotAbilityEntity, PilotAbilityDto>> pilotAbilityWebApiController,
    PilotAbilityMapper<PilotAbilityDto, PilotAbility> pilotAbilityModelMapper,

    MasterController<PilotSkillEntity, PilotSkillDto, PilotSkillMapper<PilotSkillEntity, PilotSkillDto>> pilotSkillWebApiController,
    PilotSkillModelMapper pilotSkillModelMapper,

    MasterController<SerialEntity, SerialDto, SerialMapper<SerialEntity, SerialDto>> serialWebApiController,
    SerialMapper<SerialDto, Serial> serialModelMapper,

    MasterController<SkillEntity, SkillDto, SkillMapper<SkillEntity, SkillDto>> skillWebApiController,
    SkillMapper<SkillDto, Skill> skillModelMapper,

    MasterController<SupportBadgeEntity, SupportBadgeDto, SupportBadgeMapper<SupportBadgeEntity, SupportBadgeDto>> supportBadgeWebApiController,
    SupportBadgeMapper<SupportBadgeDto, SupportBadge> supportBadgeModelMapper,

    MasterController<SupportSlotEntity, SupportSlotDto, SupportSlotMapper<SupportSlotEntity, SupportSlotDto>> supportSlotWebApiController,
    SupportSlotMapper<SupportSlotDto, SupportSlot> supportSlotModelMapper,

    MasterController<VersioningEntity, VersioningDto, VersioningMapper<VersioningEntity, VersioningDto>> versioningWebApiController,
    HttpClient httpClient,

    CoMobileWebApiController coMobileWebApiController,
    CoMobileModelMapper coMobileModelMapper,

    CuspaWebApiController cuspaWebApiController,
    CuspaModelMapper cuspaModelMapper,

    PilotWebApiController pilotWebApiController,
    PilotModelMapper pilotModelMapper,

    TagWebApiController tagWebApiController,
    TagMapper<TagDto, Tag> tagModelMapper,

    ILogger<SystemWebClient> logger) : IGw
{
    public Task<List<MobileSSkill>> SelectAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await mobileSSkillWebApiController.SelectAllAsync();
            return dtos.Select(d => mobileSSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotAbility>> SelectAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await pilotAbilityWebApiController.SelectAllAsync();
            return dtos.Select(d => pilotAbilityModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotSkill>> SelectAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await pilotSkillWebApiController.SelectAllAsync();
            return dtos.Select(d => pilotSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Serial>> SelectAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await serialWebApiController.SelectAllAsync();
            return dtos.Select(d => serialModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Skill>> SelectAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await skillWebApiController.SelectAllAsync();
            return dtos.Select(d => skillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportBadge>> SelectAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await supportBadgeWebApiController.SelectAllAsync();
            return dtos.Select(d => supportBadgeModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportSlot>> SelectAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await supportSlotWebApiController.SelectAllAsync();
            return dtos.Select(d => supportSlotModelMapper.Map(d, new())).ToList();
        });

    public Task<string> GetLocalVersionAsync() =>
        this.Execute(logger, async () =>
        {
            var dto = await versioningWebApiController.SelectByIdAsync(1);
            return dto?.Version ?? string.Empty;
        });
    public Task<string> GetRemoteVersionAsync(string uriString) =>
        this.Execute(logger, async () =>
        {
            try
            {
                return await httpClient.GetStringAsync(uriString);
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "GetRemoteVersionAsync abend. {message}", ex.Message);
                return string.Empty;
            }
        });
    public Task<bool> TryDownloadFileAsync(string uriString, string filePath) =>
        this.Execute(logger, async () =>
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, new Uri(uriString));
                using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    using var content = response.Content;
                    using var stream = await content.ReadAsStreamAsync();
                    using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                    stream.CopyTo(fileStream);
                    fileStream.Flush();
                    return true;
                }
                logger.LogWarning("StatusCode: {message}", response.StatusCode);
                return false;
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "TryDownloadFileAsync abend. {message}", ex.Message);
                return false;
            }
        });

    public Task<List<Tag>> SelectAllTagsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await tagWebApiController.SelectAllAsync();
            return dtos.Select(d => tagModelMapper.Map(d, new())).ToList();
        });

    public Task<List<CoMobile>> SelectAllCoMobilesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await coMobileWebApiController.SelectAllAsync();
            return dtos.Select(d => coMobileModelMapper.Map(d, new())).ToList();
        });

    public Task<List<Cuspa>> SelectAllCuspasAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await cuspaWebApiController.SelectAllAsync();
            return dtos.Select(d => cuspaModelMapper.Map(d, new())).ToList();
        });

    public Task<List<Pilot>> SelectAllPilotsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await pilotWebApiController.SelectAllAsync();
            return dtos.Select(d => pilotModelMapper.Map(d, new())).ToList();
        });

}
