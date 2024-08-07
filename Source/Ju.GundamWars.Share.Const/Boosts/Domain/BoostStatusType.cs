namespace Ju.GundamWars.Share.Boosts.Domain;

public enum BoostStatusType : byte
{
    None = 0,
    // ユニット ステータス
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
    SuperPower,
    AcePower,
    RecoveryPower,
    // ユニット ステータス（複合）
    BeamAndPhysicalAttack,
    BeamAndPhysicalDefence,
    EnRecovery,
    // パイロット ステータス（機体と重複以外）
    Shooting,
    Melee,
    Awakened,
    Defense,

    Unknown = byte.MaxValue,
}

public static class BoostStatusTypeExtension
{

    public static BoostStatusType ToBoostStatusType(this byte self)
    {
        try { return (BoostStatusType)self; } catch { return BoostStatusType.Unknown; }
    }

    public static byte ToValue(this BoostStatusType self) =>
        (byte)self;

    public static string ToText(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.None => GwText.None,
            BoostStatusType.Hp => GwText.Hp,
            BoostStatusType.BeamAttack => GwText.BeamAttack,
            BoostStatusType.PhysicalAttack => GwText.PhysicalAttack,
            BoostStatusType.BeamDefence => GwText.BeamDefence,
            BoostStatusType.PhysicalDefence => GwText.PhysicalDefence,
            BoostStatusType.CriticalRate => GwText.CriticalRate,
            BoostStatusType.CriticalDamage => GwText.CriticalDamage,
            BoostStatusType.Accuracy => GwText.Accuracy,
            BoostStatusType.Evasion => GwText.Evasion,
            BoostStatusType.Mobility => GwText.Mobility,
            BoostStatusType.SuperPower => GwText.SuperPower,
            BoostStatusType.AcePower => GwText.AcePower,
            BoostStatusType.RecoveryPower => GwText.RecoveryPower,
            BoostStatusType.BeamAndPhysicalAttack => GwText.BeamAndPhysicalAttack,
            BoostStatusType.BeamAndPhysicalDefence => GwText.BeamAndPhysicalDefence,
            BoostStatusType.EnRecovery => GwText.EnRecovery,
            BoostStatusType.Shooting => GwText.Shooting,
            BoostStatusType.Melee => GwText.Melee,
            BoostStatusType.Awakened => GwText.Awakened,
            BoostStatusType.Defense => GwText.Defense,
            _ => GwText.Unknown,
        };

    public static MobileStatusType[] ToMobileStatusTypes(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.Hp => [MobileStatusType.Hp,],
            BoostStatusType.BeamAttack => [MobileStatusType.BeamAttack,],
            BoostStatusType.PhysicalAttack => [MobileStatusType.PhysicalAttack,],
            BoostStatusType.BeamDefence => [MobileStatusType.BeamDefence,],
            BoostStatusType.PhysicalDefence => [MobileStatusType.PhysicalDefence,],
            BoostStatusType.CriticalRate => [MobileStatusType.CriticalRate,],
            BoostStatusType.CriticalDamage => [MobileStatusType.CriticalDamage,],
            BoostStatusType.Accuracy => [MobileStatusType.Accuracy,],
            BoostStatusType.Evasion => [MobileStatusType.Evasion,],
            BoostStatusType.Mobility => [MobileStatusType.Mobility,],
            BoostStatusType.SuperPower => [MobileStatusType.SuperPower,],
            BoostStatusType.AcePower => [MobileStatusType.AcePower,],
            BoostStatusType.RecoveryPower => [MobileStatusType.RecoveryPower,],
            BoostStatusType.BeamAndPhysicalAttack => [MobileStatusType.BeamAttack, MobileStatusType.PhysicalAttack,],
            BoostStatusType.BeamAndPhysicalDefence => [MobileStatusType.BeamDefence, MobileStatusType.PhysicalDefence,],
            BoostStatusType.EnRecovery => [MobileStatusType.SuperEnRecovery, MobileStatusType.AceEnRecovery,],
            _ => [MobileStatusType.Unknown,],
        };

    public static bool ForCuspa(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.Hp => true,
            BoostStatusType.BeamAttack => true,
            BoostStatusType.PhysicalAttack => true,
            BoostStatusType.BeamDefence => true,
            BoostStatusType.PhysicalDefence => true,
            BoostStatusType.CriticalRate => true,
            BoostStatusType.CriticalDamage => true,
            BoostStatusType.Accuracy => true,
            BoostStatusType.Evasion => true,
            BoostStatusType.Mobility => true,
            BoostStatusType.EnRecovery => true,
            _ => false,
        };

}
