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
    public Task<List<MobileSSkill>> GetAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllMobileSSkillsAsync();
            return dtos.Select(d => mobileSSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotAbility>> GetAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllPilotAbilitiesAsync();
            return dtos.Select(d => pilotAbilityModelMapper.Map(d, new())).ToList();
        });
    public Task<List<PilotSkill>> GetAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllPilotSkillsAsync();
            return dtos.Select(d => pilotSkillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Serial>> GetAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllSerialsAsync();
            return dtos.Select(d => serialModelMapper.Map(d, new())).ToList();
        });
    public Task<List<Skill>> GetAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllSkillsAsync();
            return dtos.Select(d => skillModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportBadge>> GetAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllSupportBadgesAsync();
            return dtos.Select(d => supportBadgeModelMapper.Map(d, new())).ToList();
        });
    public Task<List<SupportSlot>> GetAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var dtos = await controller.GetAllSupportSlotsAsync();
            return dtos.Select(d => supportSlotModelMapper.Map(d, new())).ToList();
        });

    public Task<string> GetLocalVersionAsync() =>
        this.Execute(logger, async () =>
        {
            var dto = await controller.GetVersioningByIdAsync();
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

}
