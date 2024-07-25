namespace Ju.GundamWars.Share.Boosts.Domain;

public interface IBooster
{

    #region Primitives

    BoostCategoryType BoostCategory { get; set; }
    BoostStatusType BoostStatus { get; set; }
    CalcMethodType CalcMethod { get; set; }
    int Value { get; set; }

    #endregion

    #region Extensions

    // TODO: 必要？
    string TargetText { get; }
    // TODO: 必要？
    string BoostText { get; }

    #endregion

}
