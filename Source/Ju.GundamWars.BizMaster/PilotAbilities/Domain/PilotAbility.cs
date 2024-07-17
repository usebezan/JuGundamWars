using Ju.GundamWars.BizMaster.Boosts.Domain;

namespace Ju.GundamWars.BizMaster.PilotAbilities.Domain;

public record PilotAbility : BoostBase, IPilotAbilityPrimitive
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
