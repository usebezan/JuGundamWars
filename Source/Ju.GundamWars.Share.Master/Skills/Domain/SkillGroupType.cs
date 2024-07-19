namespace Ju.GundamWars.Share.Skills.Domain;

public enum SkillGroupType : byte
{
    None = 0,
    Area = 1,
    SpecificTarget,
    Attribute,
    SpecialEffects,
    SpecialAttack,
    SpecialStatus,
    AbnormalStatus,
    IncreaseStatus,
    ReduceStatus,
    ResetSpecialAttack = 51,
    ResetSpecialStatus,
    ResetAbnormalStatus,
    ResetIncreaseStatus,
    ResetReduceStatus,
    ResetDisable,
    Disable = 101,
    Recover,
    IncreasePower,
    Pursuit,
    Trap,
    Other,
    Unknown = byte.MaxValue,
}

public static class SkillGroupTypeExtension
{

    public static SkillGroupType ToSkillGroupType(this byte self)
    {
        try { return (SkillGroupType)self; } catch { return SkillGroupType.Unknown; }
    }

    public static byte ToValue(this SkillGroupType self) =>
        (byte)self;

    public static string ToText(this SkillGroupType self) =>
        self switch
        {
            SkillGroupType.None => GwText.None,
            SkillGroupType.Area => "範囲",
            SkillGroupType.SpecificTarget => "特定の対象",
            SkillGroupType.Attribute => "属性",
            SkillGroupType.SpecialEffects => "特殊効果",
            SkillGroupType.SpecialAttack => "特殊攻撃",
            SkillGroupType.SpecialStatus => "特殊状態",
            SkillGroupType.AbnormalStatus => "状態異常",
            SkillGroupType.IncreaseStatus => "ステータス上昇",
            SkillGroupType.ReduceStatus => "ステータス低下",
            SkillGroupType.ResetSpecialAttack => "解除（特殊攻撃）",
            SkillGroupType.ResetSpecialStatus => "解除（特殊状態）",
            SkillGroupType.ResetAbnormalStatus => "解除（状態異常）",
            SkillGroupType.ResetIncreaseStatus => "解除（ステータス上昇）",
            SkillGroupType.ResetReduceStatus => "解除（ステータス低下）",
            SkillGroupType.ResetDisable => "解除（耐性）",
            SkillGroupType.Disable => "耐性",
            SkillGroupType.Recover => "回復",
            SkillGroupType.IncreasePower => "威力上昇",
            SkillGroupType.Pursuit => "追撃",
            SkillGroupType.Trap => "トラップ",
            SkillGroupType.Other => "その他",
            _ => GwText.Unknown,
        };

}
