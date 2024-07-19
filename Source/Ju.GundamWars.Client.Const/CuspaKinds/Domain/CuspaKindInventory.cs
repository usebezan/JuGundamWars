using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;

namespace Ju.GundamWars.Client.CuspaKinds.Domain;

public class CuspaKindInventory : MasterInventory<CuspaKind>
{
    public CuspaKindInventory()
    {
        AddRange<CuspaKindType>(e => e != CuspaKindType.Unknown, e => new(e));
    }
}
