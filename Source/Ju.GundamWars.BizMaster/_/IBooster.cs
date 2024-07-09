using Ju.GundamWars.BizMaster._.Boosts.Domain;
using Ju.GundamWars.BizMaster._.System;

namespace Ju.GundamWars.BizMaster._;

public interface IBooster
{
    BoostType Boost { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string BoostText { get; }
}
