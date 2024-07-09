using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Boosts;
using Ju.GundamWars.Domain.Calcs;

namespace Ju.GundamWars.Domain.Supports.Entities;

public class SupportBadge : IIdentify, IBooster
{

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => $"{Boost.ToStatusText()}{GetRankText()}（{this.GetUpText()}）";
    public string BoostText => Boost.ToText();
    public BoostTargetType BoostTarget => Boost.ToBoostTargetType();


    private string GetRankText() =>
        Rank switch
        {
            1 => "Ⅰ",
            2 => "Ⅱ",
            3 => "Ⅲ",
            4 => "Ⅳ",
            _ => "?"
        };

}
