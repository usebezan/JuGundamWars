using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Cuspas.Domain;

public abstract record CuspaBase<TTagLink> : ICuspa<CuspaStatusRecord, TTagLink>
    where TTagLink : ICuspaTagLink
{

    #region Primitives

    public int Id { get; set; }
    public UnitType ForUnitType { get; set; } = UnitType.MobileSuit;
    public CuspaKindType CuspaKindType { get; set; } = CuspaKindType.Special3;
    public byte Level { get; set; } = 10;
    public BoostStatusType BoostStatusType { get; set; } = BoostStatusType.Hp;
    public int BasicValue { get; set; }
    public string? Memo { get; set; }

    #endregion

    #region Primitive Models

    public CuspaStatusRecord BonusStatus { get; } = new();

    #endregion

    #region Navigations

    public List<TTagLink> TagLinks { get; set; } = [];

    #endregion

}
