namespace Ju.GundamWars.BizConst._.CuspaKinds.Domain;

public enum CuspaKindType : byte
{
    Hp2 = 1,
    BeamAttack2,
    PhysicalAttack2,
    BeamDefence2,
    PhysicalDefence2,
    Mobility2,

    Sp2Hp = 11,
    Sp2BeamAttack,
    Sp2PhysicalAttack,
    Sp2BeamDefence,
    Sp2PhysicalDefence,
    Sp2Accuracy,
    Sp2Evasion,
    Sp2Mobility,
    Sp2EnRecovery,

    Sp3Hp = 41,
    Sp3BeamAttack,
    Sp3PhysicalAttack,
    Sp3BeamDefence,
    Sp3PhysicalDefence,
    Sp3Mobility,

    SHp = 51,
    SBeamAttack,
    SPhysicalAttack,
    SBeamDefence,
    SPhysicalDefence,
    SMobility,

    Hp = 61,
    BeamAttack,
    PhysicalAttack,
    BeamDefence,
    PhysicalDefence,
    Mobility,

    Hp1 = 71,
    BeamAttack1,
    PhysicalAttack1,
    BeamDefence1,
    PhysicalDefence1,
    Mobility1,

    Unknown = byte.MaxValue,
}

public static class CuspaKindTypeExtension
{

    public static CuspaKindType ToCuspaKindType(this byte self)
    {
        try { return (CuspaKindType)self; } catch { return CuspaKindType.Unknown; }
    }

    public static byte ToValue(this CuspaKindType self) =>
        (byte)self;

    public static string ToText(this CuspaKindType self) =>
        self switch
        {
            CuspaKindType.Hp => GwText.Hp,
            CuspaKindType.BeamAttack => GwText.BeamAttack,
            CuspaKindType.PhysicalAttack => GwText.PhysicalAttack,
            CuspaKindType.BeamDefence => GwText.BeamDefence,
            CuspaKindType.PhysicalDefence => GwText.PhysicalDefence,
            CuspaKindType.Mobility => GwText.Mobility,

            CuspaKindType.Hp1 => "HP+",
            CuspaKindType.BeamAttack1 => "ビーム攻撃+",
            CuspaKindType.PhysicalAttack1 => "実弾攻撃+",
            CuspaKindType.BeamDefence1 => "ビーム防御+",
            CuspaKindType.PhysicalDefence1 => "実弾防御+",
            CuspaKindType.Mobility1 => "機動+",

            CuspaKindType.Hp2 => "HP++",
            CuspaKindType.BeamAttack2 => "ビーム攻撃++",
            CuspaKindType.PhysicalAttack2 => "実弾攻撃++",
            CuspaKindType.BeamDefence2 => "ビーム防御++",
            CuspaKindType.PhysicalDefence2 => "実弾防御++",
            CuspaKindType.Mobility2 => "機動++",

            CuspaKindType.Sp2Hp => "特殊Ⅱ HP",
            CuspaKindType.Sp2BeamAttack => "特殊Ⅱ ビーム攻撃",
            CuspaKindType.Sp2PhysicalAttack => "特殊Ⅱ 実弾攻撃",
            CuspaKindType.Sp2BeamDefence => "特殊Ⅱ ビーム防御",
            CuspaKindType.Sp2PhysicalDefence => "特殊Ⅱ 実弾防御",
            CuspaKindType.Sp2Accuracy => "特殊Ⅱ 命中",
            CuspaKindType.Sp2Evasion => "特殊Ⅱ 回避",
            CuspaKindType.Sp2Mobility => "特殊Ⅱ 機動",
            CuspaKindType.Sp2EnRecovery => "特殊Ⅱ EN回復",

            CuspaKindType.Sp3Hp => "特殊Ⅲ HP",
            CuspaKindType.Sp3BeamAttack => "特殊Ⅲ ビーム攻撃",
            CuspaKindType.Sp3PhysicalAttack => "特殊Ⅲ 実弾攻撃",
            CuspaKindType.Sp3BeamDefence => "特殊Ⅲ ビーム防御",
            CuspaKindType.Sp3PhysicalDefence => "特殊Ⅲ 実弾防御",
            CuspaKindType.Sp3Mobility => "特殊Ⅲ 機動",

            CuspaKindType.SHp => "【S】HP",
            CuspaKindType.SBeamAttack => "【S】ビーム攻撃",
            CuspaKindType.SPhysicalAttack => "【S】実弾攻撃",
            CuspaKindType.SBeamDefence => "【S】ビーム防御",
            CuspaKindType.SPhysicalDefence => "【S】実弾防御",
            CuspaKindType.SMobility => "【S】機動",

            _ => GwText.Unknown,
        };

    public static string ToGroupText(this CuspaKindType self) =>
        self switch
        {
            CuspaKindType.Hp => "HP",
            CuspaKindType.BeamAttack => "ビーム攻撃",
            CuspaKindType.PhysicalAttack => "実弾攻撃",
            CuspaKindType.BeamDefence => "ビーム防御",
            CuspaKindType.PhysicalDefence => "実弾防御",
            CuspaKindType.Mobility => "機動",

            CuspaKindType.Hp1 => "HP",
            CuspaKindType.BeamAttack1 => "ビーム攻撃",
            CuspaKindType.PhysicalAttack1 => "実弾攻撃",
            CuspaKindType.BeamDefence1 => "ビーム防御",
            CuspaKindType.PhysicalDefence1 => "実弾防御",
            CuspaKindType.Mobility1 => "機動",

            CuspaKindType.Hp2 => "HP",
            CuspaKindType.BeamAttack2 => "ビーム攻撃",
            CuspaKindType.PhysicalAttack2 => "実弾攻撃",
            CuspaKindType.BeamDefence2 => "ビーム防御",
            CuspaKindType.PhysicalDefence2 => "実弾防御",
            CuspaKindType.Mobility2 => "機動",

            CuspaKindType.Sp2Hp => "HP",
            CuspaKindType.Sp2BeamAttack => "ビーム攻撃",
            CuspaKindType.Sp2PhysicalAttack => "実弾攻撃",
            CuspaKindType.Sp2BeamDefence => "ビーム防御",
            CuspaKindType.Sp2PhysicalDefence => "実弾防御",
            CuspaKindType.Sp2Accuracy => "命中",
            CuspaKindType.Sp2Evasion => "回避",
            CuspaKindType.Sp2Mobility => "機動",
            CuspaKindType.Sp2EnRecovery => "EN回復",

            CuspaKindType.Sp3Hp => "HP",
            CuspaKindType.Sp3BeamAttack => "ビーム攻撃",
            CuspaKindType.Sp3PhysicalAttack => "実弾攻撃",
            CuspaKindType.Sp3BeamDefence => "ビーム防御",
            CuspaKindType.Sp3PhysicalDefence => "実弾防御",
            CuspaKindType.Sp3Mobility => "機動",

            CuspaKindType.SHp => "HP",
            CuspaKindType.SBeamAttack => "ビーム攻撃",
            CuspaKindType.SPhysicalAttack => "実弾攻撃",
            CuspaKindType.SBeamDefence => "ビーム防御",
            CuspaKindType.SPhysicalDefence => "実弾防御",
            CuspaKindType.SMobility => "機動",

            _ => GwText.Unknown,
        };

    public static bool ForNormal(this CuspaKindType self) =>
        !self.ForSuper();

    public static bool ForSuper(this CuspaKindType self) =>
        self == CuspaKindType.SHp ||
        self == CuspaKindType.SBeamAttack ||
        self == CuspaKindType.SPhysicalAttack ||
        self == CuspaKindType.SBeamDefence ||
        self == CuspaKindType.SPhysicalDefence ||
        self == CuspaKindType.SMobility;

}
