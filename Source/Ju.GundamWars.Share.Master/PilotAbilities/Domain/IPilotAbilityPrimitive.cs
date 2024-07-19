using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.PilotAbilities.Domain;

public interface IPilotAbilityPrimitive : IIdentify, IOrderable
{

    #region Primitives

    byte Rank { get; set; }
    BoostCategoryType BoostCategory { get; set; }
    BoostStatusType BoostStatus { get; set; }
    CalcMethodType CalcMethod { get; set; }
    int Value { get; set; }

    #endregion

}
