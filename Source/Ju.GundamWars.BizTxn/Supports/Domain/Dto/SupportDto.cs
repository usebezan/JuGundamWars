using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizConst.Units.Domain;

namespace Ju.GundamWars.BizTxn.Supports.Domain.Dto;

public class SupportDto : ISupport
{

    #region Primitives

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitType ForUnit { get; set; } = UnitType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType Grade { get; set; } = GradeType.Grade2;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    #endregion

    #region Navigations

    public List<SupportLimitedSerialMapDto> LimitedSerialMaps { get; set; } = [];
    public List<SupportTagMapDto> TagMaps { get; set; } = [];
    public List<SupportSlotBadgeDto> SlotBadges { get; set; } = [];

    #endregion

}
