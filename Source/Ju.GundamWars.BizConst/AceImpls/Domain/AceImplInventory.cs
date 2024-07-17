using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.AceImpls.Domain;

public class AceImplInventory : MasterInventory<AceImpl>
{
    public AceImplInventory()
    {
        AddRange<AceImplType>(e => e != AceImplType.Unknown, e => new(e));
    }
}
