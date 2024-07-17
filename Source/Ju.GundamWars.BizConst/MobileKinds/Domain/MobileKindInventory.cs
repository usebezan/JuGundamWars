using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.MobileKinds.Domain;

public class MobileKindInventory : MasterInventory<MobileKind>
{
    public MobileKindInventory()
    {
        AddRange<MobileKindType>(e => e != MobileKindType.Unknown, e => new(e));
    }
}
