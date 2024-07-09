using Ju.GundamWars.BizMaster.System;

namespace Ju.GundamWars.BizMaster;

public interface IBooster
{
    StatusType Boost { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string BoostText { get; }
}
