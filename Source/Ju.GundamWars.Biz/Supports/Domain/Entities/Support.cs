using Ju.GundamWars.Core.Common.Domain;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Grades;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class Support : IIdentify
{

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryType Category { get; set; } = CategoryType.MobileSuit;
    public int SerialId { get; set; } = 1;
    public GradeType Grade { get; set; } = GradeType.Grade2;
    public string? Memo { get; set; }
    public bool IsPinned { get; set; } = true;

    public List<SupportLimitedSerialMap> LimitedSerialMaps { get; set; } = new();
    public List<SupportTagMap> TagMaps { get; set; } = new();
    public List<SupportSlotBadge> SlotBadges { get; set; } = new();

}
