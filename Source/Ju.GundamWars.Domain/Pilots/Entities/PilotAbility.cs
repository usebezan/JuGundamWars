using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Boosts;
using Ju.GundamWars.Domain.Calcs;

namespace Ju.GundamWars.Domain.Pilots.Entities;

public class PilotAbility : IIdentify, IBooster
{

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => $"{Boost.ToStatusText()} Lv.{Rank}（{this.GetUpText()}）";
    public string BoostText => Boost.ToText();
    public BoostTargetType BoostTarget => Boost.ToBoostTargetType();

}
