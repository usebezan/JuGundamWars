using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.MobileSSkills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.MobileSSkills.Infrastructure.WebApi;

public class MobileSSkillWebApiController(
    ISelectByIdUseCase<MobileSSkillEntity, IMasterRepository<MobileSSkillEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<MobileSSkillEntity, IMasterRepository<MobileSSkillEntity>> selectAllServerUseCase,
    MobileSSkillMapper<MobileSSkillEntity, MobileSSkillDto> dtoMapper,
    ILogger<MobileSSkillWebApiController> logger)
        : MasterControllerBase<MobileSSkillEntity, MobileSSkillDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
