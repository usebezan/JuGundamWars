using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.PilotSkills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.PilotSkills.Infrastructure.WebApi;

public class PilotSkillWebApiController(
    ISelectByIdUseCase<PilotSkillEntity, IMasterRepository<PilotSkillEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<PilotSkillEntity, IMasterRepository<PilotSkillEntity>> selectAllServerUseCase,
    PilotSkillMapper<PilotSkillEntity, PilotSkillDto> dtoMapper,
    ILogger<PilotSkillWebApiController> logger)
        : MasterControllerBase<PilotSkillEntity, PilotSkillDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
