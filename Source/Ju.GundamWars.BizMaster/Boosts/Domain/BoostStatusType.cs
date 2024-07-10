namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public enum BoostStatusType : int
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

    Unknown = int.MaxValue,
}

public static class BoostStatusTypeExtension
{

    public static BoostStatusType ToBoostStatusType(this int self)
    {
        try { return (BoostStatusType)self; } catch { return BoostStatusType.Unknown; }
    }

    public static int ToValue(this BoostStatusType self) =>
        (int)self;

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

    public static PilotStatusType ToPilotStatusType(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.Shooting => PilotStatusType.Shooting,
            BoostStatusType.Melee => PilotStatusType.Melee,
            BoostStatusType.Accuracy => PilotStatusType.Accuracy,
            BoostStatusType.Evasion => PilotStatusType.Evasion,
            BoostStatusType.Awakened => PilotStatusType.Awakened,
            BoostStatusType.Defense => PilotStatusType.Defense,
            _ => PilotStatusType.Unknown,
        };

    public static SupportStatusType ToSupportStatusType(this BoostStatusType self) =>
        self switch
        {
            BoostStatusType.Hp => SupportStatusType.Hp,
            BoostStatusType.BeamAttack => SupportStatusType.BeamAttack,
            BoostStatusType.PhysicalAttack => SupportStatusType.PhysicalAttack,
            BoostStatusType.BeamDefence => SupportStatusType.BeamDefence,
            BoostStatusType.PhysicalDefence => SupportStatusType.PhysicalDefence,
            BoostStatusType.CriticalDamage => SupportStatusType.CriticalDamage,
            BoostStatusType.Accuracy => SupportStatusType.Accuracy,
            BoostStatusType.Evasion => SupportStatusType.Evasion,
            BoostStatusType.Mobility => SupportStatusType.Mobility,
            BoostStatusType.EnRecovery => SupportStatusType.EnRecovery,
            BoostStatusType.SuperPower => SupportStatusType.SuperPower,
            BoostStatusType.AcePower => SupportStatusType.AcePower,
            BoostStatusType.RecoveryPower => SupportStatusType.RecoveryPower,
            _ => SupportStatusType.Unknown,
        };

}
