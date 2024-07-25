using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.PilotAbilities.Infrastructure.WebApi;

public class PilotAbilityWebApiController(
    ISelectByIdUseCase<PilotAbilityEntity, IMasterRepository<PilotAbilityEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<PilotAbilityEntity, IMasterRepository<PilotAbilityEntity>> selectAllServerUseCase,
    PilotAbilityMapper<PilotAbilityEntity, PilotAbilityDto> dtoMapper,
    ILogger<PilotAbilityWebApiController> logger)
        : MasterControllerBase<PilotAbilityEntity, PilotAbilityDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
