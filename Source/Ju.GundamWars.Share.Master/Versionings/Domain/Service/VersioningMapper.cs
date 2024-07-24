using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Versionings.Domain.Service;

public class VersioningMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IVersioning
    where TDest : IVersioning
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Version = src.Version;
        return dest;
    }
}
