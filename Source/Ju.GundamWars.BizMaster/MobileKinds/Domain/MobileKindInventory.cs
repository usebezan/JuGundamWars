using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.MobileKinds.Domain;

public class MobileKindInventory : EnumObservableCollection<MobileKind>
{
    public MobileKindInventory()
    {
        AddRange<MobileKindType>(e => e != MobileKindType.Unknown, e => new(e));
    }
}
