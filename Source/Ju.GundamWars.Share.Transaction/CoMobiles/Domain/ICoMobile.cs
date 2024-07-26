using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;

namespace Ju.GundamWars.Share.CoMobiles.Domain;

public interface ICoMobile<TStatus, TTagLink> : IIdentifiable, ITagMaps<TTagLink>
    where TStatus : ICoMobileStatus
{

    #region Primitives

    string Name { get; set; }
    int SerialId { get; set; }
    RoleType RoleType { get; set; }
    byte Level { get; set; }
    TStatus BasicStatus { get; set; }
    TStatus UpgradedStatus { get; set; }
    int HpUpgradedCount { get; set; }
    int BeamAttackUpgradedCount { get; set; }
    int PhysicalAttackUpgradedCount { get; set; }
    int BeamDefenceUpgradedCount { get; set; }
    int PhysicalDefenceUpgradedCount { get; set; }
    int CriticalDamageUpgradedCount { get; set; }
    int AccuracyUpgradedCount { get; set; }
    int EvasionUpgradedCount { get; set; }
    int MobilityUpgradedCount { get; set; }
    int StartupUpgradedCount { get; set; }
    int SuperMoveUpgradedCount { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }

    #endregion

}
