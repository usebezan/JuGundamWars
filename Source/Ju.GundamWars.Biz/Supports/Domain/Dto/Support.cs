using Ju.GundamWars.BizMaster._.Categories;
using Ju.GundamWars.BizMaster.Grades;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class Support : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public UnitCategoryType ForCategory { get; set; } = UnitCategoryType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType Grade { get; set; } = GradeType.Grade2;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    public List<SupportLimitedSerialMap> LimitedSerialMaps { get; set; } = new();
    public List<SupportTagMap> TagMaps { get; set; } = new();
    public List<SupportSlotBadge> SlotBadges { get; set; } = new();

}
