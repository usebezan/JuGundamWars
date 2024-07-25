using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Cuspas.Domain;

public record CuspaBase<TTagMap> : ICuspa<TTagMap>
{

    #region Primitives

    public int Id { get; set; }
    public UnitType ForUnit { get; set; } = UnitType.MobileSuit;
    public CuspaKindType Kind { get; set; } = CuspaKindType.Special3;
    public byte Level { get; set; } = 10;
    public BoostStatusType BoostStatus { get; set; } = BoostStatusType.Hp;
    public int BasicValue { get; set; }
    public int BonusHp { get; set; }
    public int BonusBeamAttack { get; set; }
    public int BonusPhysicalAttack { get; set; }
    public int BonusBeamDefence { get; set; }
    public int BonusPhysicalDefence { get; set; }
    public int BonusCriticalRate { get; set; }
    public int BonusCriticalDamage { get; set; }
    public int BonusAccuracy { get; set; }
    public int BonusEvasion { get; set; }
    public int BonusMobility { get; set; }
    public int BonusEnRecovery { get; set; }
    public string? Memo { get; set; }

    #endregion

    #region Navigations

    public List<TTagMap> TagMaps { get; set; } = [];

    #endregion

}
