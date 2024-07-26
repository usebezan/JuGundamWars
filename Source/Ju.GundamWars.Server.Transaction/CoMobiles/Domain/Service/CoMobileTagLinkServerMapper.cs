using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileTagLinkServerMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ICoMobileTagLink
    where TDest : ICoMobileTagLink
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.CoMobileId = src.CoMobileId;
        dest.TagId = src.TagId;
        return dest;
    }
}
