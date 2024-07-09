namespace Ju.GundamWars.BizMaster._.Statuses;

public enum StatusType : byte
{
    // 機体ステータス
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
    // 機体（複合）ステータス
    EnRecovery = 51,
    BeamAndPhysicalAttack,
    BeamAndPhysicalDefence,
    // パイロット（機体と重複以外）ステータス
    Shooting = 101,
    Melee,
    Awakened,
    Defense,

    Unknown = byte.MaxValue,
}

public static class StatusTypeTypeExtension
{

    public static StatusType ToStatusTypeType(this byte self)
    {
        try { return (StatusType)self; } catch { return StatusType.Unknown; }
    }

    public static byte ToValue(this StatusType self) =>
        (byte)self;

    public static string ToText(this StatusType self) =>
        self switch
        {
            StatusType.Hp => GwText.Hp,
            StatusType.BeamAttack => GwText.BeamAttack,
            StatusType.PhysicalAttack => GwText.PhysicalAttack,
            StatusType.BeamDefence => GwText.BeamDefence,
            StatusType.PhysicalDefence => GwText.PhysicalDefence,
            StatusType.CriticalRate => GwText.CriticalRate,
            StatusType.CriticalDamage => GwText.CriticalDamage,
            StatusType.Accuracy => GwText.Accuracy,
            StatusType.Evasion => GwText.Evasion,
            StatusType.Mobility => GwText.Mobility,
            StatusType.SuperEnRecovery => GwText.SuperEnRecovery,
            StatusType.AceEnRecovery => GwText.AceEnRecovery,
            StatusType.SuperPower => GwText.SuperPower,
            StatusType.AcePower => GwText.AcePower,
            StatusType.RecoveryPower => GwText.RecoveryPower,
            StatusType.EnRecovery => GwText.EnRecovery,
            StatusType.BeamAndPhysicalAttack => GwText.BeamAndPhysicalAttack,
            StatusType.BeamAndPhysicalDefence => GwText.BeamAndPhysicalDefence,
            StatusType.Shooting => GwText.Shooting,
            StatusType.Melee => GwText.Melee,
            StatusType.Awakened => GwText.Awakened,
            StatusType.Defense => GwText.Defense,
            _ => GwText.Unknown,
        };

}
