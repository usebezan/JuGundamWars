namespace Ju.GundamWars.Domain.Pilots;

public enum PilotStatusType : byte
{
    Shooting = 1,
    Melee,
    Accuracy,
    Evasion,
    Awakened,
    Defense,
    Unknown = 255,
}

public static class PilotStatusTypeExtension
{

    public static PilotStatusType ToPilotStatusType(this byte self)
    {
        try { return (PilotStatusType)self; } catch { return PilotStatusType.Unknown; }
    }

    public static byte ToValue(this PilotStatusType self) =>
        (byte)self;

}
