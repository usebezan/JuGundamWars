using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileServerMapper<TSrc, TTagLinkSrc, TDest, TTagLinkDest> : CoMobileMapperBase<TSrc, CoMobileStatusRecord, CoMobileUpgradedCountRecord, TDest, CoMobileStatusRecord, CoMobileUpgradedCountRecord>
    where TSrc : ICoMobile<CoMobileStatusRecord, CoMobileUpgradedCountRecord, TTagLinkSrc>
    where TTagLinkSrc : ICoMobileTagLink
    where TDest : ICoMobile<CoMobileStatusRecord, CoMobileUpgradedCountRecord, TTagLinkDest>
    where TTagLinkDest : ICoMobileTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.TagLinks.Clear();
        foreach (var srcTagMap in src.TagLinks)
        {
            dest.TagLinks.Add(new() { CoMobileId = srcTagMap.CoMobileId, TagId = srcTagMap.TagId, });
        }
        return dest;
    }
}
