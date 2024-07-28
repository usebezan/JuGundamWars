using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Supports.Domain;

public record SupportBase<TLimitedSerialLink, TSlotBadge, TTagLink> : ISupport<TLimitedSerialLink, TSlotBadge, TTagLink>
    where TLimitedSerialLink : ISupportLimitedSerialLink
    where TSlotBadge : ISupportSlotBadge
    where TTagLink : ISupportTagLink
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitType ForUnitType { get; set; } = UnitType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType GradeType { get; set; } = GradeType.Grade2;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Navigations

    public List<TLimitedSerialLink> SupportLimitedSerialLinks { get; set; } = [];
    public List<TSlotBadge> SupportSlotBadges { get; set; } = [];
    public List<TTagLink> TagLinks { get; set; } = [];

    #endregion

}
