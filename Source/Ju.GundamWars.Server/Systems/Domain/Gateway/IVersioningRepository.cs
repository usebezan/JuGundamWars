using Ju.GundamWars.BizMaster.Versionings.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Server.Systems.Domain.Gateway;

public interface IVersioningRepository : ISelectByIdGateway<VersioningEntity>
{
}
