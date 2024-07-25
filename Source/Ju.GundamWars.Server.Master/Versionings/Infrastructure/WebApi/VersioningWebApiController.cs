using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Versionings.Domain;
using Ju.GundamWars.Share.Versionings.Domain;
using Ju.GundamWars.Share.Versionings.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Versionings.Infrastructure.WebApi;

public class VersioningWebApiController(
    ISelectByIdUseCase<VersioningEntity, IMasterRepository<VersioningEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<VersioningEntity, IMasterRepository<VersioningEntity>> selectAllServerUseCase,
    VersioningMapper<VersioningEntity, VersioningDto> dtoMapper,
    ILogger<VersioningWebApiController> logger)
        : MasterControllerBase<VersioningEntity, VersioningDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
