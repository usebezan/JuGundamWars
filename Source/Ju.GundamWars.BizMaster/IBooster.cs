using Ju.GundamWars.BizMaster._.Statuses;
using Ju.GundamWars.BizMaster._.System;

namespace Ju.GundamWars.BizMaster;

public interface IBooster
{
    StatusType Boost { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string BoostText { get; }
}
