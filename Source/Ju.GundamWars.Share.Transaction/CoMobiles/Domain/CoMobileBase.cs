using Ju.GundamWars.Share.Roles.Domain;

namespace Ju.GundamWars.Share.CoMobiles.Domain;

public abstract record CoMobileBase<TTagLink> : ICoMobile<CoMobileStatus, TTagLink>
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SerialId { get; set; } = 1;
    public RoleType RoleType { get; set; } = RoleType.Defensive;
    public byte Level { get; set; } = 60;
    public CoMobileStatus BasicStatus { get; set; } = new();
    public CoMobileStatus UpgradedStatus { get; set; } = new();
    public int HpUpgradedCount { get; set; }
    public int BeamAttackUpgradedCount { get; set; }
    public int PhysicalAttackUpgradedCount { get; set; }
    public int BeamDefenceUpgradedCount { get; set; }
    public int PhysicalDefenceUpgradedCount { get; set; }
    public int CriticalDamageUpgradedCount { get; set; }
    public int AccuracyUpgradedCount { get; set; }
    public int EvasionUpgradedCount { get; set; }
    public int MobilityUpgradedCount { get; set; }
    public int StartupUpgradedCount { get; set; }
    public int SuperMoveUpgradedCount { get; set; }
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Navigations

    public List<TTagLink> TagLinks { get; set; } = [];

    #endregion

}
