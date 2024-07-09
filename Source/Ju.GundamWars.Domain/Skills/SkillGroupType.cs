using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Skills;

public enum SkillGroupType : byte
{
    None = 0,
    Unknown = 255,
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
            // TODO:
            //SkillGroupType.Mobile => GwText.Mobile,
            //SkillGroupType.Battleship => GwText.Battleship,
            //SkillGroupType.Pilot => GwText.Pilot,
            //SkillGroupType.Support => GwText.Support,
            //SkillGroupType.Cuspa => GwText.Cuspa,
            //SkillGroupType.CoUnit => GwText.CoUnit,
            _ => GwTextJp.Unknown,
        };

}
