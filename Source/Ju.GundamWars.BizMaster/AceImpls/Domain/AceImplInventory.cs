using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.AceImpls.Domain;

public class AceImplInventory : EnumObservableCollection<AceImpl>
{
    public AceImplInventory()
    {
        AddRange<AceImplType>(e => e != AceImplType.Unknown, e => new(e));
    }
}
