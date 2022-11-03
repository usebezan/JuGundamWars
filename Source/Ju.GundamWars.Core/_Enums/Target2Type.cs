using System;


namespace Ju.GundamWars
{

    public enum Target2Type : byte
    {
        None = 0,

        // 機体のステータス
        Hp,
        BeamAttack,
        PhysicalAttack,
        BeamDefence,
        PhysicalDefence,
        CriticalRate,
        CriticalDamage,
        Accuracy,
        Evasion,
        Mobility,
        EnRecovery,

        // 上記以外のパイロットのステータス
        Shooting,
        Melee,
        Awakened,
        Defense,

        // 上記以外のパイロット アビリティが影響を及ぼすステータス
        BeamAndPhysicalAttack,
        BeamAndPhysicalDefence,

        // 上記以外のバッジが影響を及ぼすステータス
        SuperPower,
        AcePower,
        RecoveryPower,

        Unknown = 255,
    }


    public static class Target2TypeExtension
    {

        public static Target2Type ToTarget2Type(this byte self)
        {
            try { return (Target2Type)self; } catch { return Target2Type.Unknown; }
        }

        public static byte ToValue(this Target2Type self) =>
            (byte)self;

        public static string ToText(this Target2Type self) =>
            self switch
            {
                Target2Type.None => "なし",

                Target2Type.Hp => "HP",
                Target2Type.BeamAttack => "ビーム攻撃",
                Target2Type.PhysicalAttack => "実弾攻撃",
                Target2Type.BeamDefence => "ビーム防御",
                Target2Type.PhysicalDefence => "実弾防御",
                Target2Type.CriticalRate => "クリ率",
                Target2Type.CriticalDamage => "クリダメ",
                Target2Type.Accuracy => "命中",
                Target2Type.Evasion => "回避",
                Target2Type.Mobility => "機動",
                Target2Type.EnRecovery => "EN回復",

                Target2Type.Shooting => "射撃",
                Target2Type.Melee => "格闘",
                Target2Type.Awakened => "覚醒",
                Target2Type.Defense => "防御",

                Target2Type.BeamAndPhysicalAttack => "ビーム・実弾攻撃",
                Target2Type.BeamAndPhysicalDefence => "ビーム・実弾防御",

                Target2Type.SuperPower => "必殺技の威力",
                Target2Type.AcePower => "ACE必殺技の威力",
                Target2Type.RecoveryPower => "必殺技のHP回復力",

                _ => "不明",
            };

        public static bool IsUnit(this Target2Type self) =>
            self switch
            {
                Target2Type.Hp => true,
                Target2Type.BeamAttack => true,
                Target2Type.PhysicalAttack => true,
                Target2Type.BeamDefence => true,
                Target2Type.PhysicalDefence => true,
                Target2Type.CriticalRate => true,
                Target2Type.CriticalDamage => true,
                Target2Type.Accuracy => true,
                Target2Type.Evasion => true,
                Target2Type.Mobility => true,
                Target2Type.EnRecovery => true,
                _ => false,
            };

    }

}
