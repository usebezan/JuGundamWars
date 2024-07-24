using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.MobileSSkills.Domain.Service;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain.Service;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Server.Systems.Infrastructure.WebApi;
using Ju.GundamWars.Share.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain.Service;
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
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Infrastructure.WebClient;

public class SystemWebClient(
    SystemWebApiController controller,
    HttpClient httpClient,
    MobileSSkillModelMapper mobileSSkillModelMapper,
    PilotAbilityMapper<PilotAbilityDto, PilotAbility> pilotAbilityModelMapper,
    PilotSkillModelMapper pilotSkillModelMapper,
    SerialMapper<SerialDto, Serial> serialModelMapper,
    SkillMapper<SkillDto, Skill> skillModelMapper,
    SupportBadgeMapper<SupportBadgeDto, SupportBadge> supportBadgeModelMapper,
    SupportSlotMapper<SupportSlotDto, SupportSlot> supportSlotModelMapper,

    TagMapper<TagDto, Tag> tagModelMapper,

    ILogger<SystemWebClient> logger
    ) : IGw
{

    public Task<List<MobileSSkill>> GetAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllMobileSSkillsAsync();
            return dtos.Select(d => mobileSSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotAbility>> GetAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllPilotAbilitiesAsync();
            return dtos.Select(d => pilotAbilityModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotSkill>> GetAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllPilotSkillsAsync();
            return dtos.Select(d => pilotSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Serial>> GetAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSerialsAsync();
            return dtos.Select(d => serialModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Skill>> GetAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSkillsAsync();
            return dtos.Select(d => skillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportBadge>> GetAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSupportBadgesAsync();
            return dtos.Select(d => supportBadgeModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportSlot>> GetAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllSupportSlotsAsync();
            return dtos.Select(d => supportSlotModelMapper.Map(d, new())).ToList();
        });

    public Task<string> GetLocalVersionAsync() =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.SelectVersioningByIdAsync();
            return dto.Version;
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

    public Task<List<Tag>> GetAllTagsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.SelectAllTagsAsync();
            return dtos.Select(d => tagModelMapper.Map(d, new())).ToList();
        });

}
