using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Supports.Domain;

public interface ISupport : IIdentifiable
{

    #region Primitives

    string Name { get; set; }
    UnitType ForUnitType { get; set; }
    int SerialId { get; set; }
    GradeType GradeType { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }

    #endregion

}

public interface ISupport<TLimitedSerialLink, TSlotBadge, TTagLink> : ISupport, ITagMaps<TTagLink>
    where TLimitedSerialLink : ISupportLimitedSerialLink
    where TSlotBadge : ISupportSlotBadge
    where TTagLink : ISupportTagLink
{

    #region Navigations

    List<TLimitedSerialLink> SupportLimitedSerialLinks { get; set; }
    List<TSlotBadge> SupportSlotBadges { get; set; }

    #endregion

}
