namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public interface IBooster
{
    BoostStatusType BoostStatus { get; }
    CalcType Calc { get; }
    decimal Value { get; }
    string TargetText { get; }
    string BoostText { get; }
}
