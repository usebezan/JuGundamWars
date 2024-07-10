namespace Ju.GundamWars.BizMaster.Skills.Domain;

public enum SkillGroupType : byte
{
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
            _ => GwText.Unknown,
        };

}
