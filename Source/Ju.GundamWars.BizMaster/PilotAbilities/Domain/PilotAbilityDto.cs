using Ju.GundamWars.BizConst.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.PilotAbilities.Domain;

public class PilotAbilityDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostCategoryType BoostCategory { get; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    #endregion

}
