using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.PilotAbilities.Domain;

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
