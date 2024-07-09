namespace Ju.GundamWars.BizMaster.Terrains;

public enum TerrainType : byte
{
    Grade1 = 1,
    Grade2,
    Grade3,
    Unknown = byte.MaxValue,
}

public static class TerrainTypeExtension
{

    public static TerrainType ToTerrainType(this byte self)
    {
        try { return (TerrainType)self; } catch { return TerrainType.Unknown; }
    }

    public static byte ToValue(this TerrainType self) =>
        (byte)self;

    public static string ToText(this TerrainType self) =>
        self switch
        {
            TerrainType.Grade1 => "◎",
            TerrainType.Grade2 => "○",
            TerrainType.Grade3 => "△",
            _ => GwText.Unknown,
        };

}
