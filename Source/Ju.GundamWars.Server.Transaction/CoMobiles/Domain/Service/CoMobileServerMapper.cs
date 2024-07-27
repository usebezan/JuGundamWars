using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileServerMapper<TSrc, TSrcTagLink, TDest, TDestTagLink> : CoMobileMapperBase<TSrc, CoMobileStatusRecord, CoMobileUpgradedCountRecord, TDest, CoMobileStatusRecord, CoMobileUpgradedCountRecord>
    where TSrc : ICoMobile<CoMobileStatusRecord, CoMobileUpgradedCountRecord, TSrcTagLink>
    where TSrcTagLink : ICoMobileTagLink
    where TDest : ICoMobile<CoMobileStatusRecord, CoMobileUpgradedCountRecord, TDestTagLink>
    where TDestTagLink : ICoMobileTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.TagLinks.Clear();
        foreach (var srcTagLink in src.TagLinks)
        {
            dest.TagLinks.Add(new() { CoMobileId = srcTagLink.CoMobileId, TagId = srcTagLink.TagId, });
        }
        return dest;
    }
}
