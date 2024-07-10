using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Biz.Supports.Domain;

public interface ISupport : IIdentify
{
    string Name { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }
}
