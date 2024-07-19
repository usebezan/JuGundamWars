using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportBadges.Domain;

public record SupportBadgePrimitiveBase : ISupportBadgePrimitive
{

    #region Primitives

    public int Id { get; set; }
    public byte Rank { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }

    #endregion

}
