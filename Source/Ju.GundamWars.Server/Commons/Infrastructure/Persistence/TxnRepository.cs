using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public class TxnRepository<T>(IDbContextFactory<GwTxnDbContext> factory, ILogger<TxnRepository<T>> logger)
    : RepositoryBase<GwTxnDbContext, T>(factory, logger), ITxnGateway<T>
    where T : class, IIdentifiable
{
}
