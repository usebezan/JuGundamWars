namespace Ju.GundamWars.Share.Pilots.Domain;

public record PilotStatusRecord : IPilotStatus
{

    #region Primitives

    public int Shooting { get; set; }
    public int Melee { get; set; }
    public int Accuracy { get; set; }
    public int Evasion { get; set; }
    public int Awakened { get; set; }
    public int Defense { get; set; }

    #endregion

}
