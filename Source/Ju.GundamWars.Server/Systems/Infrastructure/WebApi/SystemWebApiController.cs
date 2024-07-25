using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Server.MobileSSkills.Domain;
using Ju.GundamWars.Server.PilotAbilities.Domain;
using Ju.GundamWars.Server.PilotSkills.Domain;
using Ju.GundamWars.Server.Serials.Domain;
using Ju.GundamWars.Server.Skills.Domain;
using Ju.GundamWars.Server.SupportBadges.Domain;
using Ju.GundamWars.Server.SupportSlots.Domain;
using Ju.GundamWars.Server.Tags.Domain;
using Ju.GundamWars.Server.Versionings.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;
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

namespace Ju.GundamWars.Server.Systems.Infrastructure.WebApi;

public class SystemWebApiController(
    ISelectAllUseCase<MobileSSkillEntity, IMasterGateway<MobileSSkillEntity>> selectAllMobileSSkillsServerUseCase,
    MobileSSkillMapper<MobileSSkillEntity, MobileSSkillDto> mobileSSkillDtoMapper,
    ISelectAllUseCase<PilotAbilityEntity, IMasterGateway<PilotAbilityEntity>> selectAllPilotAbilitiesServerUseCase,
    PilotAbilityMapper<PilotAbilityEntity, PilotAbilityDto> pilotAbilityDtoMapper,
    ISelectAllUseCase<PilotSkillEntity, IMasterGateway<PilotSkillEntity>> selectAllPilotSkillsServerUseCase,
    PilotSkillMapper<PilotSkillEntity, PilotSkillDto> pilotSkillDtoMapper,
    ISelectAllUseCase<SerialEntity, IMasterGateway<SerialEntity>> selectAllSerialsServerUseCase,
    SerialMapper<SerialEntity, SerialDto> serialDtoMapper,
    ISelectAllUseCase<SkillEntity, IMasterGateway<SkillEntity>> selectAllSkillsServerUseCase,
    SkillMapper<SkillEntity, SkillDto> skillDtoMapper,
    ISelectAllUseCase<SupportBadgeEntity, IMasterGateway<SupportBadgeEntity>> selectAllSupportBadgesServerUseCase,
    SupportBadgeMapper<SupportBadgeEntity, SupportBadgeDto> supportBadgeDtoMapper,
    ISelectAllUseCase<SupportSlotEntity, IMasterGateway<SupportSlotEntity>> selectAllSupportSlotsServerUseCase,
    SupportSlotMapper<SupportSlotEntity, SupportSlotDto> supportSlotDtoMapper,

    ISelectByIdUseCase<VersioningEntity, IMasterGateway<VersioningEntity>> selectVersioningByIdServerUseCase,
    VersioningMapper<VersioningEntity, VersioningDto> versioningDtoMapper,

    ISelectAllUseCase<TagEntity, ITxnGateway<TagEntity>> selectAllTagsServerUseCase,
    TagMapper<TagEntity, TagDto> TagDtoMapper,

    ISelectAllUseCase<CoMobileEntity, ICoMobileRepository> selectAllCoMobileServerUseCase,
    CoMobileMapper<CoMobileEntity, CoMobileDto, CoMobileTagMapEntity, CoMobileTagMapDto> coMobileDtoMapper,

    ILogger<SystemWebApiController> logger) : IGw
{

    public Task<List<MobileSSkillDto>> SelectAllMobileSSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllMobileSSkillsServerUseCase.HandleAsync();
            return entities.Select(e => mobileSSkillDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<PilotAbilityDto>> SelectAllPilotAbilitiesAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllPilotAbilitiesServerUseCase.HandleAsync();
            return entities.Select(e => pilotAbilityDtoMapper.Map(e, new())).ToList();
        });
    public Task<List<PilotSkillDto>> SelectAllPilotSkillsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllPilotSkillsServerUseCase.HandleAsync();
            return entities.Select(e => pilotSkillDtoMapper.Map(e, new())).ToList();
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

    public Task<VersioningDto> SelectVersioningByIdAsync() =>
        this.Execute(logger, async () =>
        {
            var entity = await selectVersioningByIdServerUseCase.HandleAsync(1);
            var dto = new VersioningDto();
            return entity == null ? dto : versioningDtoMapper.Map(entity, dto);
        });

    public Task<List<TagDto>> SelectAllTagsAsync() =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllTagsServerUseCase.HandleAsync();
            return entities.Select(e => TagDtoMapper.Map(e, new())).ToList();
        });

    public Task<List<CoMobileDto>> SelectAllAsync(CoMobileDto dto) =>
        this.Execute(logger, async () =>
        {
            var entities = await selectAllCoMobileServerUseCase.HandleAsync();
            return entities.Select(e => coMobileDtoMapper.Map(e, new())).ToList();
        });

}
