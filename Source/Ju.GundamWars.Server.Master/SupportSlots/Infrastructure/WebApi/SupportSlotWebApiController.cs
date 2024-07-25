using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.WebApi;
using Ju.GundamWars.Server.SupportSlots.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain.Service;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.SupportSlots.Infrastructure.WebApi;

public class SupportSlotWebApiController(
    ISelectByIdUseCase<SupportSlotEntity, IMasterRepository<SupportSlotEntity>> selectByIdServerUseCase,
    ISelectAllUseCase<SupportSlotEntity, IMasterRepository<SupportSlotEntity>> selectAllServerUseCase,
    SupportSlotMapper<SupportSlotEntity, SupportSlotDto> dtoMapper,
    ILogger<SupportSlotWebApiController> logger)
        : MasterControllerBase<SupportSlotEntity, SupportSlotDto>(selectByIdServerUseCase, selectAllServerUseCase, dtoMapper, logger)
{
}
