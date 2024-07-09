namespace Ju.GundamWars.Supports.Domain;

public enum SupportStatusType : byte
{
    Hp = 1,
    BeamAttack,
    PhysicalAttack,
    BeamDefence,
    PhysicalDefence,
    CriticalDamage,
    Accuracy,
    Evasion,
    Mobility,
    EnRecovery,
    SuperPower,
    AcePower,
    RecoveryPower,
    Unknown = 255,
}

public static class SupportStatusTypeExtension
{

    public static SupportStatusType ToSupportStatusType(this byte self)
    {
        try { return (SupportStatusType)self; } catch { return SupportStatusType.Unknown; }
    }

    public static byte ToValue(this SupportStatusType self) =>
        (byte)self;

}
