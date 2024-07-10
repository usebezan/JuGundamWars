using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizConst.AceImpls.Domain;

public class AceImplInventory : MasterObservableCollection<AceImpl>
{
    public AceImplInventory()
    {
        AddRange<AceImplType>(e => e != AceImplType.Unknown, e => new(e));
    }
}
