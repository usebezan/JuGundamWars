using Ju.GundamWars.Domain.Boosts;
using Ju.GundamWars.Domain.Calcs;

namespace Ju.GundamWars.Domain;

public interface IBooster
{
    BoostType Boost { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string BoostText { get; }
}
