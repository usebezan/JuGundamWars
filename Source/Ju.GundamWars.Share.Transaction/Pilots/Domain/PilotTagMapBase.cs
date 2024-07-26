namespace Ju.GundamWars.Share.Pilots.Domain;

public record PilotTagMapBase : IPilotTagMap
{

    #region Primitives

    public int PilotId { get; set; }
    public int TagId { get; set; }

    #endregion

}
