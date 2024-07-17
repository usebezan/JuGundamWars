using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.CuspaKinds.Domain;

public class CuspaKindInventory : MasterInventory<CuspaKind>
{
    public CuspaKindInventory()
    {
        AddRange<CuspaKindType>(e => e != CuspaKindType.Unknown, e => new(e));
    }
}
