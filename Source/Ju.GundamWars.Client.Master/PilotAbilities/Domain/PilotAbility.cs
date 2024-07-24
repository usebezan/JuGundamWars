using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.PilotAbilities.Domain;

namespace Ju.GundamWars.Client.PilotAbilities.Domain;

public record PilotAbility : BoostBase, IPilotAbility
{

    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public int Order { get; set; }

    #endregion

    #region Extensions

    public string Name => $"{BoostStatus.ToText()} Lv.{Rank}（{BoostText}）";

    #endregion

}
