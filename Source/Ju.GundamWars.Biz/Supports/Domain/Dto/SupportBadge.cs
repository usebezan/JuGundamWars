using Ju.GundamWars.BizMaster;
using Ju.GundamWars.BizMaster._.Boosts;
using Ju.GundamWars.BizMaster._.System;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Common.Domain;
using Ju.GundamWars.Core.Ju.GundamWars;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Boosts;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class SupportBadge : IIdentify, IBooster
{

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostStatusType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => $"{Boost.ToStatusText()}{GetRankText()}（{this.GetUpText()}）";
    public string BoostText => Boost.ToText();
    public BoostUnitType BoostTarget => Boost.ToBoostUnitType();


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
