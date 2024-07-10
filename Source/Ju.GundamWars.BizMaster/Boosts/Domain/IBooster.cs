namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public interface IBooster
{
    BoostStatusType BoostStatus { get; }
    CalcMethodType CalcMethod { get; }
    decimal Value { get; }
    string TargetText { get; }
    string BoostText { get; }
}
