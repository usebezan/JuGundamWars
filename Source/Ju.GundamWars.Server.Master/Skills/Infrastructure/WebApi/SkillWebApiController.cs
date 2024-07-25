using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Skills.Domain;
using Ju.GundamWars.Share.Skills.Domain;
using Ju.GundamWars.Share.Skills.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Skills.Infrastructure.WebApi;

public class SkillWebApiController(
    ISelectByIdUseCase<SkillEntity, IMasterRepository<SkillEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<SkillEntity, IMasterRepository<SkillEntity>> selectAllServerUseCase,
    SkillMapper<SkillEntity, SkillDto> dtoMapper,
    ILogger<SkillWebApiController> logger)
        : MasterControllerBase<SkillEntity, SkillDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
