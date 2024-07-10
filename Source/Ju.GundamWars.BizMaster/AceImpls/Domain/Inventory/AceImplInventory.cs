using Ju.GundamWars.BizMaster.AceImpls.Domain.Model;
using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.AceImpls.Domain.Inventory;

public class AceImplInventory : MasterObservableCollection<AceImpl>
{
    public AceImplInventory()
    {
        AddRange<AceImplType>(e => e != AceImplType.Unknown, e => new(e));
    }
}
