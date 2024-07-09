using Ju.GundamWars.Domain.Roles;

namespace Ju.GundamWars.Domain.CoUnits.Dto;

public class CoUnit : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SerialId { get; set; } = 1;
    public RoleType Role { get; set; } = RoleType.Defensive;
    public byte Level { get; set; } = 60;
    public int Hp { get; set; }
    public int BeamAttack { get; set; }
    public int PhysicalAttack { get; set; }
    public int BeamDefence { get; set; }
    public int PhysicalDefence { get; set; }
    public int CriticalDamage { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Mobility { get; set; }
    public int UpgradedHp { get; set; }
    public int UpgradedBeamAttack { get; set; }
    public int UpgradedPhysicalAttack { get; set; }
    public int UpgradedBeamDefence { get; set; }
    public int UpgradedPhysicalDefence { get; set; }
    public int UpgradedCriticalDamage { get; set; }
    public int UpgradedAccuracy { get; set; }
    public int UpgradedEvasion { get; set; }
    public int UpgradedMobility { get; set; }
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

    public List<CoUnitTagMap> TagMaps { get; set; } = [];

}
