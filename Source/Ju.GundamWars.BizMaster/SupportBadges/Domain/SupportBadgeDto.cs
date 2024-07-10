using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.SupportBadges.Domain;

public class SupportBadgeDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    #endregion

}
