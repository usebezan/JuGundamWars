using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain;

public interface IBooster
{
    BoostType Boost { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string BoostText { get; }
}
