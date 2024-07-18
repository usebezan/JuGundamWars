using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public class VersioningPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : IVersioningPrimitive
    where TDest : IVersioningPrimitive
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Version = src.Version;
        return dest;
    }
}
