using Ju.GundamWars.BizMaster.Units;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Biz.Supports.Domain;

public interface ISupport : IIdentify
{
    string Name { get; set; }
    UnitType ForUnit { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }
}
