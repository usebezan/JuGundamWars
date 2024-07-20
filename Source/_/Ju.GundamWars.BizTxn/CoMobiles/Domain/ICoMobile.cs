using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain;

public interface ICoMobile : IIdentify
{
    string Name { get; set; }
    byte Level { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }
}
