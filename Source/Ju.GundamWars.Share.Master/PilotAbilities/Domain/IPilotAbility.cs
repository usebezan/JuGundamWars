using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.PilotAbilities.Domain;

public interface IPilotAbility : IIdentifiable, IOrderable
{

    #region Primitives

    byte Rank { get; set; }
    BoostCategoryType BoostCategoryType { get; set; }
    BoostStatusType BoostStatusType { get; set; }
    CalcMethodType CalcMethodType { get; set; }
    int Value { get; set; }

    #endregion

}
