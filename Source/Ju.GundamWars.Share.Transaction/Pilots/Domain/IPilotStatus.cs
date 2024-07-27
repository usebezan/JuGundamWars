namespace Ju.GundamWars.Share.Pilots.Domain;

public interface IPilotStatus
{

    #region Primitives

    int Shooting { get; set; }
    int Melee { get; set; }
    int Accuracy { get; set; }
    int Evasion { get; set; }
    int Awakened { get; set; }
    int Defense { get; set; }

    #endregion

}
