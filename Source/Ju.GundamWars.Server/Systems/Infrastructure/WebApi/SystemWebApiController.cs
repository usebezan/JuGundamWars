using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.MobileSSkills.Domain;
using Ju.GundamWars.Server.PilotAbilities.Domain;
using Ju.GundamWars.Server.PilotSkills.Domain;
using Ju.GundamWars.Server.Serials.Domain;
using Ju.GundamWars.Server.Skills.Domain;
using Ju.GundamWars.Server.SupportBadges.Domain;
using Ju.GundamWars.Server.SupportSlots.Domain;
using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Server.Versionings.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.Serials.Domain;
using Ju.GundamWars.Share.Skills.Domain;
using Ju.GundamWars.Share.SupportBadges.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Versionings.Domain;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Systems.Infrastructure.WebApi;

public class SystemWebApiController(
    ISelectAllServerUseCase<MobileSSkillEntity, IMasterGateway<MobileSSkillEntity>> selectAllMobileSSkillsServerUseCase,
    MobileSSkillPrimitiveMapper<MobileSSkillEntity, MobileSSkillDto> mobileSSkillDtoMapper,
    ISelectAllServerUseCase<PilotAbilityEntity, IMasterGateway<PilotAbilityEntity>> selectAllPilotAbilitiesServerUseCase,
    PilotAbilityPrimitiveMapper<PilotAbilityEntity, PilotAbilityDto> pilotAbilityDtoMapper,
    ISelectAllServerUseCase<PilotSkillEntity, IMasterGateway<PilotSkillEntity>> selectAllPilotSkillsServerUseCase,
    PilotSkillPrimitiveMapper<PilotSkillEntity, PilotSkillDto> pilotSkillDtoMapper,
    ISelectAllServerUseCase<SerialEntity, IMasterGateway<SerialEntity>> selectAllSerialsServerUseCase,
    SerialPrimitiveMapper<SerialEntity, SerialDto> serialDtoMapper,
    ISelectAllServerUseCase<SkillEntity, IMasterGateway<SkillEntity>> selectAllSkillsServerUseCase,
    SkillPrimitiveMapper<SkillEntity, SkillDto> skillDtoMapper,
    ISelectAllServerUseCase<SupportBadgeEntity, IMasterGateway<SupportBadgeEntity>> selectAllSupportBadgesServerUseCase,
    SupportBadgePrimitiveMapper<SupportBadgeEntity, SupportBadgeDto> supportBadgeDtoMapper,
    ISelectAllServerUseCase<SupportSlotEntity, IMasterGateway<SupportSlotEntity>> selectAllSupportSlotsServerUseCase,
    SupportSlotPrimitiveMapper<SupportSlotEntity, SupportSlotDto> supportSlotDtoMapper,

    ISelectByIdServerUseCase<VersioningEntity, IMasterGateway<VersioningEntity>> selectVersioningByIdServerUseCase,
    VersioningPrimitiveMapper<VersioningEntity, VersioningDto> versioningDtoMapper,

    ISelectAllServerUseCase<TagEntity, ITxnGateway<TagEntity>> selectAllTagsServerUseCase,
    TagPrimitiveMapper<TagEntity, TagDto> TagDtoMapper,

    ILogger<SystemWebApiController> logger) : IGw
{

    public Task<List<MobileSSkillDto>> GetAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllMobileSSkillsServerUseCase.HandleAsync();
            return entities.Select(e => mobileSSkillDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<PilotAbilityDto>> GetAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllPilotAbilitiesServerUseCase.HandleAsync();
            return entities.Select(e => pilotAbilityDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<PilotSkillDto>> GetAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllPilotSkillsServerUseCase.HandleAsync();
            return entities.Select(e => pilotSkillDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SerialDto>> GetAllSerialsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSerialsServerUseCase.HandleAsync();
            return entities.Select(e => serialDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SkillDto>> GetAllSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSkillsServerUseCase.HandleAsync();
            return entities.Select(e => skillDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportBadgeDto>> GetAllSupportBadgesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSupportBadgesServerUseCase.HandleAsync();
            return entities.Select(e => supportBadgeDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<SupportSlotDto>> GetAllSupportSlotsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllSupportSlotsServerUseCase.HandleAsync();
            return entities.Select(e => supportSlotDtoMapper.Map(e, new())).ToList();
        });

    public Task<VersioningDto> GetVersioningByIdAsync() =>
        this.Execute(logger, async () =>
        {
            var entity = await selectVersioningByIdServerUseCase.HandleAsync(1);
            var dto = new VersioningDto();
            return entity == null ? dto : versioningDtoMapper.Map(entity, dto);
        });

    public Task<List<TagDto>> GetAllTagsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllTagsServerUseCase.HandleAsync();
            return entities.Select(e => TagDtoMapper.Map(e, new())).ToList();
        });

}
