using Ju.GundamWars.BizConst.Units.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizTxn.Supports.Domain;

public interface ISupport : IIdentify
{
    string Name { get; set; }
    UnitType ForUnit { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }
}
