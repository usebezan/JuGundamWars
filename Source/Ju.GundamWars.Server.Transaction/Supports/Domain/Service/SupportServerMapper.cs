using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.Supports.Domain.Service;

namespace Ju.GundamWars.Server.Supports.Domain.Service;

public class SupportServerMapper<TSrc, TSrcLimitedSerialLink, TSrcSlotBadge, TSrcTagLink, TDest, TDestLimitedSerialLink, TDestSlotBadge, TDestTagLink>
    : SupportMapperBase<TSrc, TDest>
    where TSrc : ISupport<TSrcLimitedSerialLink, TSrcSlotBadge, TSrcTagLink>
    where TSrcLimitedSerialLink : ISupportLimitedSerialLink
    where TSrcSlotBadge : ISupportSlotBadge
    where TSrcTagLink : ISupportTagLink
    where TDest : ISupport<TDestLimitedSerialLink, TDestSlotBadge, TDestTagLink>
    where TDestLimitedSerialLink : ISupportLimitedSerialLink, new()
    where TDestSlotBadge : ISupportSlotBadge, new()
    where TDestTagLink : ISupportTagLink, new()
{
    public override TDest Map(TSrc src, TDest dest)
    {
        MapCore(src, dest);
        dest.SupportLimitedSerialLinks.Clear();
        foreach (var srcLimitedSerialLink in src.SupportLimitedSerialLinks)
        {
            dest.SupportLimitedSerialLinks.Add(new() { SupportId = srcLimitedSerialLink.SupportId, SerialId = srcLimitedSerialLink.SerialId, });
        }
        dest.SupportSlotBadges.Clear();
        foreach (var srcSlotBadge in src.SupportSlotBadges)
        {
            dest.SupportSlotBadges.Add(new() { SupportId = srcSlotBadge.SupportId, Seq = srcSlotBadge.Seq, SupportSlotId = srcSlotBadge.SupportSlotId, SupportBadgeId = srcSlotBadge.SupportBadgeId, });
        }
        dest.TagLinks.Clear();
        foreach (var srcTagLink in src.TagLinks)
        {
            dest.TagLinks.Add(new() { SupportId = srcTagLink.SupportId, TagId = srcTagLink.TagId, });
        }
        return dest;
    }
}
