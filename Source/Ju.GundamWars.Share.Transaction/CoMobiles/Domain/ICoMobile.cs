using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Roles.Domain;

namespace Ju.GundamWars.Share.CoMobiles.Domain;

public interface ICoMobile : IIdentifiable
{

    #region Primitives

    string Name { get; set; }
    int SerialId { get; set; }
    RoleType Role { get; set; }
    byte Level { get; set; }
    int Hp { get; set; }
    int BeamAttack { get; set; }
    int PhysicalAttack { get; set; }
    int BeamDefence { get; set; }
    int PhysicalDefence { get; set; }
    int CriticalDamage { get; set; }
    int Accuracy { get; set; }
    int Evasion { get; set; }
    int Mobility { get; set; }
    int UpgradedHp { get; set; }
    int UpgradedBeamAttack { get; set; }
    int UpgradedPhysicalAttack { get; set; }
    int UpgradedBeamDefence { get; set; }
    int UpgradedPhysicalDefence { get; set; }
    int UpgradedCriticalDamage { get; set; }
    int UpgradedAccuracy { get; set; }
    int UpgradedEvasion { get; set; }
    int UpgradedMobility { get; set; }
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
