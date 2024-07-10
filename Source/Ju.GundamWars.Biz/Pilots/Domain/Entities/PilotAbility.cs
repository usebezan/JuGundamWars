using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Boosts;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Pilots.Domain.Entities;

public class PilotAbility : IIdentify, IBooster
{

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostStatusType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => $"{Boost.ToStatusText()} Lv.{Rank}（{this.GetUpText()}）";
    public string BoostText => Boost.ToText();
    public BoostUnitType BoostCategory => Boost.ToBoostUnitType();

}
