using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.Versionings.Domain;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Systems.Domain.Gateway;
using Microsoft.Extensions.Logging;
using MobileSSkillDtoMapper = Ju.GundamWars.BizMaster.MobileSSkills.Domain.MobileSSkillPrimitiveMapper<Ju.GundamWars.BizMaster.MobileSSkills.Domain.MobileSSkillEntity, Ju.GundamWars.BizMaster.MobileSSkills.Domain.MobileSSkillDto>;
using SelectAllMobileSSkillsServerUseCase = Ju.GundamWars.Server.Commons.UseCase.InputPort.ISelectAllServerUseCase<Ju.GundamWars.BizMaster.MobileSSkills.Domain.MobileSSkillEntity, Ju.GundamWars.Server.Commons.Domain.Gateway.IMasterRepository<Ju.GundamWars.BizMaster.MobileSSkills.Domain.MobileSSkillEntity>>;

namespace Ju.GundamWars.Server.Systems.Infrastructure.WebApi;

public class SystemWebApiController(
    SelectAllMobileSSkillsServerUseCase selectAllMobileSSkillsServerUseCase,
    MobileSSkillDtoMapper mobileSSkillDtoMapper,
    ISelectAllServerUseCase<PilotAbilityEntity, IMasterRepository<PilotAbilityEntity>> selectAllPilotAbilitiesServerUseCase,
    PilotAbilityPrimitiveMapper<PilotAbilityEntity, PilotAbilityDto> pilotAbilityDtoMapper,
    ISelectAllServerUseCase<PilotSkillEntity, IMasterRepository<PilotSkillEntity>> selectAllPilotSkillsServerUseCase,
    PilotSkillPrimitiveMapper<PilotSkillEntity, PilotSkillDto> pilotSkillDtoMapper,
    ISelectAllServerUseCase<SerialEntity, IMasterRepository<SerialEntity>> selectAllSerialsServerUseCase,
    SerialPrimitiveMapper<SerialEntity, SerialDto> serialDtoMapper,
    ISelectAllServerUseCase<SkillEntity, IMasterRepository<SkillEntity>> selectAllSkillsServerUseCase,
    SkillPrimitiveMapper<SkillEntity, SkillDto> skillDtoMapper,
    ISelectAllServerUseCase<SupportBadgeEntity, IMasterRepository<SupportBadgeEntity>> selectAllSupportBadgesServerUseCase,
    SupportBadgePrimitiveMapper<SupportBadgeEntity, SupportBadgeDto> supportBadgeDtoMapper,
    ISelectAllServerUseCase<SupportSlotEntity, IMasterRepository<SupportSlotEntity>> selectAllSupportSlotsServerUseCase,
    SupportSlotPrimitiveMapper<SupportSlotEntity, SupportSlotDto> supportSlotDtoMapper,
    ISelectByIdServerUseCase<VersioningEntity, IVersioningRepository> selectVersioningByIdServerUseCase,
    VersioningPrimitiveMapper<VersioningEntity, VersioningDto> versioningDtoMapper,
    ILogger<SystemWebApiController> logger
    ) : IGw
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
}
