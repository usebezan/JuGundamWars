using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileTagMapMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ICoMobileTagMap
    where TDest : ICoMobileTagMap
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.CoMobileId = src.CoMobileId;
        dest.TagId = src.TagId;
        return dest;
    }
}
