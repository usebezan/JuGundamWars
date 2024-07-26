using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportBadges.Domain;

public interface ISupportBadge : IIdentifiable, IOrderable
{

    #region Primitives

    byte Rank { get; set; }
    BoostStatusType BoostStatusType { get; set; }
    CalcMethodType CalcMethodType { get; set; }
    int Value { get; set; }

    #endregion

}
