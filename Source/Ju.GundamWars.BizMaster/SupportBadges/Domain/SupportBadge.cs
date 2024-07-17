using Ju.GundamWars.BizMaster.Boosts.Domain;

namespace Ju.GundamWars.BizMaster.SupportBadges.Domain;

public record SupportBadge : BoostBase, ISupportBadgePrimitive
{

    public SupportBadge()
    {
        BoostCategory = BoostCategoryType.Mobile;
    }


    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public int Order { get; set; }

    #endregion

    #region Extensions

    public string Name => $"{BoostStatus.ToText()}{GetRankText()}（{BoostText}）";

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
