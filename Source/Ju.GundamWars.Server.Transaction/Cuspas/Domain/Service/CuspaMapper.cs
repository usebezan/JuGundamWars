using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Server.Cuspas.Domain.Service;

public class CuspaMapper<TSrc, TDest, TTagMapSrc, TTagMapDest>(CuspaTagMapMapper<TTagMapSrc, TTagMapDest> coMobileTagMapMapper) : IMapper<TSrc, TDest>
    where TSrc : ICuspa<TTagMapSrc>
    where TDest : ICuspa<TTagMapDest>
    where TTagMapSrc : ICuspaTagMap
    where TTagMapDest : ICuspaTagMap, new()
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.ForUnit = src.ForUnit;
        dest.Kind = src.Kind;
        dest.Level = src.Level;
        dest.BoostStatus = src.BoostStatus;
        dest.BasicValue = src.BasicValue;
        dest.BonusHp = src.BonusHp;
        dest.BonusBeamAttack = src.BonusBeamAttack;
        dest.BonusPhysicalAttack = src.BonusPhysicalAttack;
        dest.BonusBeamDefence = src.BonusBeamDefence;
        dest.BonusPhysicalDefence = src.BonusPhysicalDefence;
        dest.BonusCriticalRate = src.BonusCriticalRate;
        dest.BonusCriticalDamage = src.BonusCriticalDamage;
        dest.BonusAccuracy = src.BonusAccuracy;
        dest.BonusEvasion = src.BonusEvasion;
        dest.BonusMobility = src.BonusMobility;
        dest.BonusEnRecovery = src.BonusEnRecovery;
        dest.Memo = src.Memo;
        dest.TagMaps.Clear();
        foreach (var srcTagMap in src.TagMaps)
        {
            dest.TagMaps.Add(coMobileTagMapMapper.Map(srcTagMap, new()));
        }
        return dest;
    }
}
