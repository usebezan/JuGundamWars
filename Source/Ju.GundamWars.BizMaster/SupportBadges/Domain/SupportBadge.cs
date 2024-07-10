using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;

namespace Ju.GundamWars.BizMaster.SupportBadges.Domain;

public record SupportBadge : BoostBase
{

    public SupportBadge(int Id, byte Rank, BoostStatusType BoostStatus, CalcMethodType CalcMethod, decimal Value, int Order)
        : base(BoostCategoryType.Mobile, BoostStatus, CalcMethod, Value)
    {
        this.Id = Id;
        this.Rank = Rank;
        this.Order = Order;
        Name = $"{BoostStatus.ToText()}{GetRankText()}（{BoostText}）";
    }


    #region Primitives

    public int Id { get; }
    public byte Rank { get; }
    public int Order { get; }

    #endregion

    #region Extensions

    public string Name { get; }

    #endregion


    private string GetRankText() =>
        Rank switch
        {
            1 => "Ⅰ",
            2 => "Ⅱ",
            3 => "Ⅲ",
            4 => "Ⅳ",
            _ => "？"
        };

}
