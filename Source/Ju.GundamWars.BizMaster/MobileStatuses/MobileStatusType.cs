namespace Ju.GundamWars.BizMaster.MobileStatuses;

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
    Unknown = byte.MaxValue,
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
            MobileStatusType.Hp => GwText.Hp,
            MobileStatusType.BeamAttack => GwText.BeamAttack,
            MobileStatusType.PhysicalAttack => GwText.PhysicalAttack,
            MobileStatusType.BeamDefence => GwText.BeamDefence,
            MobileStatusType.PhysicalDefence => GwText.PhysicalDefence,
            MobileStatusType.CriticalRate => GwText.CriticalRate,
            MobileStatusType.CriticalDamage => GwText.CriticalDamage,
            MobileStatusType.Accuracy => GwText.Accuracy,
            MobileStatusType.Evasion => GwText.Evasion,
            MobileStatusType.Mobility => GwText.Mobility,
            MobileStatusType.SuperEnRecovery => GwText.SuperEnRecovery,
            MobileStatusType.AceEnRecovery => GwText.AceEnRecovery,
            MobileStatusType.SuperPower => GwText.SuperPower,
            MobileStatusType.AcePower => GwText.AcePower,
            MobileStatusType.RecoveryPower => GwText.RecoveryPower,
            _ => GwText.Unknown,
        };

}
