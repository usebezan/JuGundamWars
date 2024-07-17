using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Systems.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Systems.Application;

internal class LoadAllServerInteractor(
    IMasterRepository<PilotAbilityEntity> pilotAbilityRepository,
    IMasterRepository<SerialEntity> serialRepository,
    IMasterRepository<SkillEntity> skillRepository,
    IMasterRepository<SupportBadgeEntity> supportBadgeRepository,
    ILogger<LoadAllServerInteractor> logger)
    : ILoadAllServerUseCase, IGw
{
    public Task<DataEntities> HandleAsync() =>
        this.Execute(logger, async () =>
            new DataEntities
            {
                PilotAbilities = await pilotAbilityRepository.SelectAllAsync(),
                Serials = await serialRepository.SelectAllAsync(),
                Skills = await skillRepository.SelectAllAsync(),
                SupportBadges = await supportBadgeRepository.SelectAllAsync(),
            }
        );
}
