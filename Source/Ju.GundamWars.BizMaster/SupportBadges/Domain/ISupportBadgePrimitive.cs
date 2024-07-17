using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.SupportBadges.Domain;

public interface ISupportBadgePrimitive : IIdentify, IOrderable
{

    #region Primitives

    public byte Rank { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public int Value { get; set; }

    #endregion

}
