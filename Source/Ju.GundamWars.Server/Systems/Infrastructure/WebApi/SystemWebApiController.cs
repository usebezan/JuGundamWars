using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Systems.Infrastructure.WebApi;

public class SystemWebApiController(
    ISelectAllServerUseCase<PilotAbilityEntity, IMasterRepository<PilotAbilityEntity>> selectAllPilotAbilitiesServerUseCase,
    PilotAbilityPrimitiveMapper<PilotAbilityEntity, PilotAbilityDto> pilotAbilityDtoMapper,
    ISelectAllServerUseCase<SerialEntity, IMasterRepository<SerialEntity>> selectAllSerialsServerUseCase,
    SerialPrimitiveMapper<SerialEntity, SerialDto> serialDtoMapper,
    ISelectAllServerUseCase<SkillEntity, IMasterRepository<SkillEntity>> selectAllSkillsServerUseCase,
    SkillPrimitiveMapper<SkillEntity, SkillDto> skillDtoMapper,
    ISelectAllServerUseCase<SupportBadgeEntity, IMasterRepository<SupportBadgeEntity>> selectAllSupportBadgesServerUseCase,
    SupportBadgePrimitiveMapper<SupportBadgeEntity, SupportBadgeDto> supportBadgeDtoMapper,
    ISelectAllServerUseCase<SupportSlotEntity, IMasterRepository<SupportSlotEntity>> selectAllSupportSlotsServerUseCase,
    SupportSlotPrimitiveMapper<SupportSlotEntity, SupportSlotDto> supportSlotDtoMapper,
    ILogger<SystemWebApiController> logger
    ) : IGw
{
    public Task<List<PilotAbilityDto>> SelectAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllPilotAbilitiesServerUseCase.HandleAsync();
            return entities.Select(e => pilotAbilityDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SerialDto>> SelectAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSerialsServerUseCase.HandleAsync();
            return entities.Select(e => serialDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SkillDto>> SelectAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSkillsServerUseCase.HandleAsync();
            return entities.Select(e => skillDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportBadgeDto>> SelectAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSupportBadgesServerUseCase.HandleAsync();
            return entities.Select(e => supportBadgeDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportSlotDto>> SelectAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSupportSlotsServerUseCase.HandleAsync();
            return entities.Select(e => supportSlotDtoMapper.Map(e, new())).ToList();
        });
}
