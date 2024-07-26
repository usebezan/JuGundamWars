using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportBadges.Domain;

public record SupportBadgeBase : ISupportBadge
{

    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostStatusType BoostStatusType { get; set; }
    public CalcMethodType CalcMethodType { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }

    #endregion

}
