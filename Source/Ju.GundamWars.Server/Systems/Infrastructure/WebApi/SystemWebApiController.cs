using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.Server.Systems.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Systems.Infrastructure.WebApi;

public class SystemWebApiController(
    ILoadAllServerUseCase loadAllServerUseCase,
    PilotAbilityPrimitiveMapper<PilotAbilityEntity, PilotAbilityDto> pilotAbilityDtoMapper,
    SerialPrimitiveMapper<SerialEntity, SerialDto> serialDtoMapper,
    SkillPrimitiveMapper<SkillEntity, SkillDto> skillDtoMapper,
    SupportBadgePrimitiveMapper<SupportBadgeEntity, SupportBadgeDto> supportBadgeDtoMapper,
    ILogger<SystemWebApiController> logger
    ) : IGw
{
    public Task<DataDtos> LoadAllAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await loadAllServerUseCase.HandleAsync();
            var dtos = new DataDtos
            {
                PilotAbilities = entities.PilotAbilities.Select(e => pilotAbilityDtoMapper.Map(e, new())).ToList(),
                Serials = entities.Serials.Select(e => serialDtoMapper.Map(e, new())).ToList(),
                Skills = entities.Skills.Select(e => skillDtoMapper.Map(e, new())).ToList(),
                SupportBadges = entities.SupportBadges.Select(e => supportBadgeDtoMapper.Map(e, new())).ToList(),
            };
            return dtos;
        });
}
