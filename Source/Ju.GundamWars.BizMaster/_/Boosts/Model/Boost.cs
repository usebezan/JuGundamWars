using Ju.GundamWars.BizMaster._.Categories;
using Ju.GundamWars.BizMaster._.Statuses;

namespace Ju.GundamWars.BizMaster._.Boosts.Model;

public record Boost(BoostUnitType UnitType, StatusType StatusType)
{
    public string Name => $"{UnitType.ToText()} の {StatusType.ToText()}";
    public bool ForMobile => UnitType == BoostUnitType.Mobile;
    public bool ForPilot => UnitType == BoostUnitType.Pilot;
    public bool ForBadge => UnitType == BoostUnitType.Badge;
}

/*

    public static MobileStatusType[] ToMobileStatusTypes(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.MobileHp => [MobileStatusType.Hp,],
            BoostStatusType.MobileBeamAttack => [MobileStatusType.BeamAttack,],
            BoostStatusType.MobilePhysicalAttack => [MobileStatusType.PhysicalAttack,],
            BoostStatusType.MobileBeamDefence => [MobileStatusType.BeamDefence,],
            BoostStatusType.MobilePhysicalDefence => [MobileStatusType.PhysicalDefence,],
            BoostStatusType.MobileCriticalRate => [MobileStatusType.CriticalRate,],
            BoostStatusType.MobileCriticalDamage => [MobileStatusType.CriticalDamage,],
            BoostStatusType.MobileAccuracy => [MobileStatusType.Accuracy,],
            BoostStatusType.MobileEvasion => [MobileStatusType.Evasion,],
            BoostStatusType.MobileMobility => [MobileStatusType.Mobility,],
            BoostStatusType.MobileEnRecovery => [MobileStatusType.SuperEnRecovery, MobileStatusType.AceEnRecovery,],
            BoostStatusType.MobileBeamAndPhysicalAttack => [MobileStatusType.BeamAttack, MobileStatusType.PhysicalAttack,],
            BoostStatusType.MobileBeamAndPhysicalDefence => [MobileStatusType.BeamDefence, MobileStatusType.PhysicalDefence,],
            BoostStatusType.MobileSuperPower => [MobileStatusType.SuperPower,],
            BoostStatusType.MobileAcePower => [MobileStatusType.AcePower,],
            BoostStatusType.MobileRecoveryPower => [MobileStatusType.RecoveryPower,],
            _ => [MobileStatusType.Unknown,],
        };

    public static PilotStatusType ToPilotStatusType(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.PilotShooting => PilotStatusType.Shooting,
            BoostStatusType.PilotMelee => PilotStatusType.Melee,
            BoostStatusType.PilotAccuracy => PilotStatusType.Accuracy,
            BoostStatusType.PilotEvasion => PilotStatusType.Evasion,
            BoostStatusType.PilotAwakened => PilotStatusType.Awakened,
            BoostStatusType.PilotDefense => PilotStatusType.Defense,
            _ => PilotStatusType.Unknown,
        };

    public static SupportStatusType ToSupportStatusType(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.MobileHp => SupportStatusType.Hp,
            BoostStatusType.MobileBeamAttack => SupportStatusType.BeamAttack,
            BoostStatusType.MobilePhysicalAttack => SupportStatusType.PhysicalAttack,
            BoostStatusType.MobileBeamDefence => SupportStatusType.BeamDefence,
            BoostStatusType.MobilePhysicalDefence => SupportStatusType.PhysicalDefence,
            BoostStatusType.MobileCriticalDamage => SupportStatusType.CriticalDamage,
            BoostStatusType.MobileAccuracy => SupportStatusType.Accuracy,
            BoostStatusType.MobileEvasion => SupportStatusType.Evasion,
            BoostStatusType.MobileMobility => SupportStatusType.Mobility,
            BoostStatusType.MobileEnRecovery => SupportStatusType.EnRecovery,
            BoostStatusType.MobileSuperPower => SupportStatusType.SuperPower,
            BoostStatusType.MobileAcePower => SupportStatusType.AcePower,
            BoostStatusType.MobileRecoveryPower => SupportStatusType.RecoveryPower,
            _ => SupportStatusType.Unknown,
        };
*/
