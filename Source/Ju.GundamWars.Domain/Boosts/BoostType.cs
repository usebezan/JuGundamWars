using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Boosts;

[Flags]
public enum BoostType : int
{
    None = 0,

    Mobile = GwConst.MobileFlag,
    MobileHp,
    MobileBeamAttack,
    MobilePhysicalAttack,
    MobileBeamDefence,
    MobilePhysicalDefence,
    MobileCriticalRate,
    MobileCriticalDamage,
    MobileAccuracy,
    MobileEvasion,
    MobileMobility,
    MobileEnRecovery,
    MobileBeamAndPhysicalAttack,
    MobileBeamAndPhysicalDefence,
    MobileSuperPower,
    MobileAcePower,
    MobileRecoveryPower,

    Pilot = GwConst.PilotFlag,
    PilotShooting,
    PilotMelee,
    PilotAccuracy,
    PilotEvasion,
    PilotAwakened,
    PilotDefense,

    Badge = GwConst.BadgeFlag,
    BadgeHp,
    BadgeBeamAttack,
    BadgePhysicalAttack,
    BadgeBeamDefence,
    BadgePhysicalDefence,
    BadgeCriticalDamage,
    BadgeAccuracy,
    BadgeEvasion,
    BadgeMobility,
    BadgeEnRecovery,
    BadgeSuperPower,
    BadgeAcePower,
    BadgeRecoveryPower,

    Unknown = int.MaxValue,
}

public static class BoostTypeExtension
{

    public static BoostType ToBoostType(this int self)
    {
        try { return (BoostType)self; } catch { return BoostType.Unknown; }
    }

    public static int ToValue(this BoostType self) =>
        (int)self;


    public static BoostTargetType ToBoostTargetType(this BoostType self)
    {
        if (self == BoostType.None)
        {
            return BoostTargetType.None;
        }
        else if (self.HasFlag(BoostType.Mobile))
        {
            return BoostTargetType.Mobile;
        }
        else if (self.HasFlag(BoostType.Pilot))
        {
            return BoostTargetType.Pilot;
        }
        else if (self.HasFlag(BoostType.Badge))
        {
            return BoostTargetType.Badge;
        }
        else
        {
            return BoostTargetType.Unknown;
        }
    }

    public static MobileStatusType[] ToMobileStatusTypes(this BoostType self) =>
        self switch
        {
            BoostType.MobileHp => [MobileStatusType.Hp,],
            BoostType.MobileBeamAttack => [MobileStatusType.BeamAttack,],
            BoostType.MobilePhysicalAttack => [MobileStatusType.PhysicalAttack,],
            BoostType.MobileBeamDefence => [MobileStatusType.BeamDefence,],
            BoostType.MobilePhysicalDefence => [MobileStatusType.PhysicalDefence,],
            BoostType.MobileCriticalRate => [MobileStatusType.CriticalRate,],
            BoostType.MobileCriticalDamage => [MobileStatusType.CriticalDamage,],
            BoostType.MobileAccuracy => [MobileStatusType.Accuracy,],
            BoostType.MobileEvasion => [MobileStatusType.Evasion,],
            BoostType.MobileMobility => [MobileStatusType.Mobility,],
            BoostType.MobileEnRecovery => [MobileStatusType.SuperEnRecovery, MobileStatusType.AceEnRecovery,],
            BoostType.MobileBeamAndPhysicalAttack => [MobileStatusType.BeamAttack, MobileStatusType.PhysicalAttack,],
            BoostType.MobileBeamAndPhysicalDefence => [MobileStatusType.BeamDefence, MobileStatusType.PhysicalDefence,],
            BoostType.MobileSuperPower => [MobileStatusType.SuperPower,],
            BoostType.MobileAcePower => [MobileStatusType.AcePower,],
            BoostType.MobileRecoveryPower => [MobileStatusType.RecoveryPower,],
            _ => [MobileStatusType.Unknown,],
        };

    public static PilotStatusType ToPilotStatusType(this BoostType self) =>
        self switch
        {
            BoostType.PilotShooting => PilotStatusType.Shooting,
            BoostType.PilotMelee => PilotStatusType.Melee,
            BoostType.PilotAccuracy => PilotStatusType.Accuracy,
            BoostType.PilotEvasion => PilotStatusType.Evasion,
            BoostType.PilotAwakened => PilotStatusType.Awakened,
            BoostType.PilotDefense => PilotStatusType.Defense,
            _ => PilotStatusType.Unknown,
        };

    public static SupportStatusType ToSupportStatusType(this BoostType self) =>
        self switch
        {
            BoostType.MobileHp => SupportStatusType.Hp,
            BoostType.MobileBeamAttack => SupportStatusType.BeamAttack,
            BoostType.MobilePhysicalAttack => SupportStatusType.PhysicalAttack,
            BoostType.MobileBeamDefence => SupportStatusType.BeamDefence,
            BoostType.MobilePhysicalDefence => SupportStatusType.PhysicalDefence,
            BoostType.MobileCriticalDamage => SupportStatusType.CriticalDamage,
            BoostType.MobileAccuracy => SupportStatusType.Accuracy,
            BoostType.MobileEvasion => SupportStatusType.Evasion,
            BoostType.MobileMobility => SupportStatusType.Mobility,
            BoostType.MobileEnRecovery => SupportStatusType.EnRecovery,
            BoostType.MobileSuperPower => SupportStatusType.SuperPower,
            BoostType.MobileAcePower => SupportStatusType.AcePower,
            BoostType.MobileRecoveryPower => SupportStatusType.RecoveryPower,
            _ => SupportStatusType.Unknown,
        };

    public static string ToTargetText(this BoostType self) =>
        self.ToBoostTargetType().ToText();

    public static string ToStatusText(this BoostType self)
    {
        switch (self)
        {
            case BoostType.None:
                return GwTextJp.None;
            case BoostType.MobileHp:
            case BoostType.BadgeHp:
                return GwTextJp.Hp;
            case BoostType.MobileBeamAttack:
            case BoostType.BadgeBeamAttack:
                return GwTextJp.BeamAttack;
            case BoostType.MobilePhysicalAttack:
            case BoostType.BadgePhysicalAttack:
                return GwTextJp.PhysicalAttack;
            case BoostType.MobileBeamDefence:
            case BoostType.BadgeBeamDefence:
                return GwTextJp.BeamDefence;
            case BoostType.MobilePhysicalDefence:
            case BoostType.BadgePhysicalDefence:
                return GwTextJp.PhysicalDefence;
            case BoostType.MobileCriticalRate:
                return GwTextJp.CriticalRate;
            case BoostType.MobileCriticalDamage:
            case BoostType.BadgeCriticalDamage:
                return GwTextJp.CriticalDamage;
            case BoostType.MobileAccuracy:
            case BoostType.PilotAccuracy:
            case BoostType.BadgeAccuracy:
                return GwTextJp.Accuracy;
            case BoostType.MobileEvasion:
            case BoostType.PilotEvasion:
            case BoostType.BadgeEvasion:
                return GwTextJp.Evasion;
            case BoostType.MobileMobility:
            case BoostType.BadgeMobility:
                return GwTextJp.Mobility;
            case BoostType.MobileEnRecovery:
            case BoostType.BadgeEnRecovery:
                return GwTextJp.EnRecovery;
            case BoostType.MobileBeamAndPhysicalAttack:
                return GwTextJp.BeamAndPhysicalAttack;
            case BoostType.MobileBeamAndPhysicalDefence:
                return GwTextJp.BeamAndPhysicalDefence;
            case BoostType.MobileSuperPower:
            case BoostType.BadgeSuperPower:
                return GwTextJp.SuperPower;
            case BoostType.MobileAcePower:
            case BoostType.BadgeAcePower:
                return GwTextJp.AcePower;
            case BoostType.MobileRecoveryPower:
            case BoostType.BadgeRecoveryPower:
                return GwTextJp.RecoveryPower;
            case BoostType.PilotShooting:
                return GwTextJp.Shooting;
            case BoostType.PilotMelee:
                return GwTextJp.Melee;
            case BoostType.PilotAwakened:
                return GwTextJp.Awakened;
            case BoostType.PilotDefense:
                return GwTextJp.Defense;
            default:
                return GwTextJp.Unknown;
        }
    }

    public static string ToText(this BoostType self) =>
        $"{self.ToTargetText()} の {self.ToStatusText()}";

    public static bool IsSameStatus(this BoostType self, BoostType boost) =>
        self switch
        {
            BoostType.MobileHp => boost == BoostType.BadgeHp,
            BoostType.MobileBeamAttack => boost == BoostType.BadgeBeamAttack,
            BoostType.MobilePhysicalAttack => boost == BoostType.BadgePhysicalAttack,
            BoostType.MobileBeamDefence => boost == BoostType.BadgeBeamDefence,
            BoostType.MobilePhysicalDefence => boost == BoostType.BadgePhysicalDefence,
            BoostType.MobileCriticalDamage => boost == BoostType.BadgeCriticalDamage,
            BoostType.MobileAccuracy => boost == BoostType.BadgeAccuracy,
            BoostType.MobileEvasion => boost == BoostType.BadgeEvasion,
            BoostType.MobileMobility => boost == BoostType.BadgeMobility,
            BoostType.MobileEnRecovery => boost == BoostType.BadgeEnRecovery,
            BoostType.MobileSuperPower => boost == BoostType.BadgeSuperPower,
            BoostType.MobileAcePower => boost == BoostType.BadgeAcePower,
            BoostType.MobileRecoveryPower => boost == BoostType.BadgeRecoveryPower,
            BoostType.BadgeHp => boost == BoostType.MobileHp,
            BoostType.BadgeBeamAttack => boost == BoostType.MobileBeamAttack,
            BoostType.BadgePhysicalAttack => boost == BoostType.MobilePhysicalAttack,
            BoostType.BadgeBeamDefence => boost == BoostType.MobileBeamDefence,
            BoostType.BadgePhysicalDefence => boost == BoostType.MobilePhysicalDefence,
            BoostType.BadgeCriticalDamage => boost == BoostType.MobileCriticalDamage,
            BoostType.BadgeAccuracy => boost == BoostType.MobileAccuracy,
            BoostType.BadgeEvasion => boost == BoostType.MobileEvasion,
            BoostType.BadgeMobility => boost == BoostType.MobileMobility,
            BoostType.BadgeEnRecovery => boost == BoostType.MobileEnRecovery,
            BoostType.BadgeSuperPower => boost == BoostType.MobileSuperPower,
            BoostType.BadgeAcePower => boost == BoostType.MobileAcePower,
            BoostType.BadgeRecoveryPower => boost == BoostType.MobileRecoveryPower,
            _ => false,
        };

    public static bool ForMobile(this BoostType self) =>
        self.HasFlag(BoostType.Mobile);

    public static bool ForBadge(this BoostType self) =>
        self.HasFlag(BoostType.Badge);

}
