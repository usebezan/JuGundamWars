using Ju.GundamWars.BizMaster.MobileKinds.Domain.Model;
using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.MobileKinds.Domain.Inventory;

public class MobileKindInventory : MasterObservableCollection<MobileKind>
{
    public MobileKindInventory()
    {
        AddRange<MobileKindType>(e => e != MobileKindType.Unknown, e => new(e));
    }
}
