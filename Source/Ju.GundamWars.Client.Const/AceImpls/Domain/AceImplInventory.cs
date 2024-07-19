using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.AceImpls.Domain;

namespace Ju.GundamWars.Client.AceImpls.Domain;

public class AceImplInventory : MasterInventory<AceImpl>
{
    public AceImplInventory()
    {
        AddRange<AceImplType>(e => e != AceImplType.Unknown, e => new(e));
    }
}
