namespace Ju.GundamWars.BizMaster.PilotStatuses.Domain;

public enum PilotStatusType : byte
{
    Shooting = 1,
    Melee,
    Accuracy,
    Evasion,
    Awakened,
    Defense,
    Unknown = byte.MaxValue,
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
