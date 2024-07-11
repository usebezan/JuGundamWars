using Ju.GundamWars.BizConst.Units.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizTxn.Cuspas.Domain;

public interface ICuspa : IIdentify
{
    UnitType ForUnit { get; set; }
    byte Level { get; set; }
    int BasicValue { get; set; }
    string? Memo { get; set; }
}
