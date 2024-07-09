using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Mobiles;

public enum MobileStatusType : byte
{
    Hp = 1,
    BeamAttack,
    PhysicalAttack,
    BeamDefence,
    PhysicalDefence,
    CriticalRate,
    CriticalDamage,
    Accuracy,
    Evasion,
    Mobility,
    SuperEnRecovery,
    AceEnRecovery,
    SuperPower,
    AcePower,
    RecoveryPower,
    Unknown = 255,
}

public static class MobileStatusTypeExtension
{

    public static MobileStatusType ToMobileStatusType(this byte self)
    {
        try { return (MobileStatusType)self; } catch { return MobileStatusType.Unknown; }
    }

    public static byte ToValue(this MobileStatusType self) =>
        (byte)self;

    public static string ToText(this MobileStatusType self) =>
        self switch
        {
            MobileStatusType.Hp => GwTextJp.Hp,
            MobileStatusType.BeamAttack => GwTextJp.BeamAttack,
            MobileStatusType.PhysicalAttack => GwTextJp.PhysicalAttack,
            MobileStatusType.BeamDefence => GwTextJp.BeamDefence,
            MobileStatusType.PhysicalDefence => GwTextJp.PhysicalDefence,
            MobileStatusType.CriticalRate => GwTextJp.CriticalRate,
            MobileStatusType.CriticalDamage => GwTextJp.CriticalDamage,
            MobileStatusType.Accuracy => GwTextJp.Accuracy,
            MobileStatusType.Evasion => GwTextJp.Evasion,
            MobileStatusType.Mobility => GwTextJp.Mobility,
            MobileStatusType.SuperEnRecovery => GwTextJp.SuperEnRecovery,
            MobileStatusType.AceEnRecovery => GwTextJp.AceEnRecovery,
            MobileStatusType.SuperPower => GwTextJp.SuperPower,
            MobileStatusType.AcePower => GwTextJp.AcePower,
            MobileStatusType.RecoveryPower => GwTextJp.RecoveryPower,
            _ => GwTextJp.Unknown,
        };

}
