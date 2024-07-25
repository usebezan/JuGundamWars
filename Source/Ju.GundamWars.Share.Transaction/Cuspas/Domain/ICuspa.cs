using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Cuspas.Domain;

public interface ICuspa<TTagMap> : IIdentifiable, ITagMaps<TTagMap>
{

    #region Primitives

    UnitType ForUnit { get; set; }
    CuspaKindType Kind { get; set; }
    byte Level { get; set; }
    BoostStatusType BoostStatus { get; set; }
    int BasicValue { get; set; }
    int BonusHp { get; set; }
    int BonusBeamAttack { get; set; }
    int BonusPhysicalAttack { get; set; }
    int BonusBeamDefence { get; set; }
    int BonusPhysicalDefence { get; set; }
    int BonusCriticalRate { get; set; }
    int BonusCriticalDamage { get; set; }
    int BonusAccuracy { get; set; }
    int BonusEvasion { get; set; }
    int BonusMobility { get; set; }
    int BonusEnRecovery { get; set; }
    string? Memo { get; set; }

    #endregion

}
