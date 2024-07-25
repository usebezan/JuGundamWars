using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.Serials.Domain;
using Ju.GundamWars.Share.Serials.Domain;
using Ju.GundamWars.Share.Serials.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Serials.Infrastructure.WebApi;

public class SerialWebApiController(
    ISelectByIdUseCase<SerialEntity, IMasterRepository<SerialEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<SerialEntity, IMasterRepository<SerialEntity>> selectAllServerUseCase,
    SerialMapper<SerialEntity, SerialDto> dtoMapper,
    ILogger<SerialWebApiController> logger)
        : MasterControllerBase<SerialEntity, SerialDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
