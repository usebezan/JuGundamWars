using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileServerMapper<TSrc, TTagLinkSrc, TDest, TTagLinkDest>(CoMobileTagLinkServerMapper<TTagLinkSrc, TTagLinkDest> tagLinkMapper) : IMapper<TSrc, TDest>
    where TSrc : ICoMobile<CoMobileStatus, TTagLinkSrc>
    where TTagLinkSrc : ICoMobileTagLink
    where TDest : ICoMobile<CoMobileStatus, TTagLinkDest>
    where TTagLinkDest : ICoMobileTagLink, new()
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.SerialId = src.SerialId;
        dest.RoleType = src.RoleType;
        dest.Level = src.Level;
        dest.BasicStatus.Set(src.BasicStatus);
        dest.UpgradedStatus.Set(src.UpgradedStatus);
        dest.HpUpgradedCount = src.HpUpgradedCount;
        dest.BeamAttackUpgradedCount = src.BeamAttackUpgradedCount;
        dest.PhysicalAttackUpgradedCount = src.PhysicalAttackUpgradedCount;
        dest.BeamDefenceUpgradedCount = src.BeamDefenceUpgradedCount;
        dest.PhysicalDefenceUpgradedCount = src.PhysicalDefenceUpgradedCount;
        dest.CriticalDamageUpgradedCount = src.CriticalDamageUpgradedCount;
        dest.AccuracyUpgradedCount = src.AccuracyUpgradedCount;
        dest.EvasionUpgradedCount = src.EvasionUpgradedCount;
        dest.MobilityUpgradedCount = src.MobilityUpgradedCount;
        dest.StartupUpgradedCount = src.StartupUpgradedCount;
        dest.SuperMoveUpgradedCount = src.SuperMoveUpgradedCount;
        dest.Memo = src.Memo;
        dest.IsPinned = src.IsPinned;
        dest.TagLinks.Clear();
        foreach (var srcTagMap in src.TagLinks)
        {
            dest.TagLinks.Add(tagLinkMapper.Map(srcTagMap, new()));
        }
        return dest;
    }
}
