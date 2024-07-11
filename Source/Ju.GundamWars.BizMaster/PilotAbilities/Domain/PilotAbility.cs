using Ju.GundamWars.BizConst.Boosts.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;

namespace Ju.GundamWars.BizMaster.PilotAbilities.Domain;

public record PilotAbility : BoostBase
{

    public PilotAbility(int Id, byte Rank, BoostCategoryType BoostCategory, BoostStatusType BoostStatus, CalcMethodType CalcMethod, decimal Value, int Order)
        : base(BoostCategory, BoostStatus, CalcMethod, Value)
    {
        this.Id = Id;
        this.Rank = Rank;
        this.Order = Order;
        Name = $"{BoostStatus.ToText()} Lv.{Rank}（{BoostText}）";
    }


    #region Primitives

    public int Id { get; }
    public byte Rank { get; }
    public int Order { get; }

    #endregion

    #region Extensions

    public string Name { get; }

    #endregion

}
