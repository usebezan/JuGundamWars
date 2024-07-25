using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.Tags.Domain;

namespace Ju.GundamWars.Server.CoMobiles.Domain.Service;

public class CoMobileMapper<TSrc, TDest, TTagSrc, TTagDest>(CoMobileTagMapMapper<TTagSrc, TTagDest> coMobileTagMapMapper) : IMapper<TSrc, TDest>
    where TSrc : ICoMobile, ITagMaps<TTagSrc>
    where TDest : ICoMobile, ITagMaps<TTagDest>
    where TTagSrc : ICoMobileTagMap
    where TTagDest : ICoMobileTagMap, new()
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.SerialId = src.SerialId;
        dest.Role = src.Role;
        dest.Level = src.Level;
        dest.Hp = src.Hp;
        dest.BeamAttack = src.BeamAttack;
        dest.PhysicalAttack = src.PhysicalAttack;
        dest.BeamDefence = src.BeamDefence;
        dest.PhysicalDefence = src.PhysicalDefence;
        dest.CriticalDamage = src.CriticalDamage;
        dest.Accuracy = src.Accuracy;
        dest.Evasion = src.Evasion;
        dest.Mobility = src.Mobility;
        dest.UpgradedHp = src.UpgradedHp;
        dest.UpgradedBeamAttack = src.UpgradedBeamAttack;
        dest.UpgradedPhysicalAttack = src.UpgradedPhysicalAttack;
        dest.UpgradedBeamDefence = src.UpgradedBeamDefence;
        dest.UpgradedPhysicalDefence = src.UpgradedPhysicalDefence;
        dest.UpgradedCriticalDamage = src.UpgradedCriticalDamage;
        dest.UpgradedAccuracy = src.UpgradedAccuracy;
        dest.UpgradedEvasion = src.UpgradedEvasion;
        dest.UpgradedMobility = src.UpgradedMobility;
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
        dest.TagMaps.Clear();
        foreach (var srcTagMap in src.TagMaps)
        {
            dest.TagMaps.Add(coMobileTagMapMapper.Map(srcTagMap, new()));
        }
        return dest;
    }
}
