using Ju.GundamWars.Application.Systems.Repositories;
using Ju.GundamWars.Domain.Systems.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Serials;

public class SerialRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<SerialRepository> logger)
    : ReadOnlyRepositoryBase<Serial, GwMasterDbContext>(factory, logger), ISerialRepository
{

    public override List<Serial> SelectAll() => Execute(dbContext => dbContext.Set<Serial>().OrderBy(e => e.Order).ToList());

}
