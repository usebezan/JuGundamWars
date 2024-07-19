using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.MobileKinds.Domain;

namespace Ju.GundamWars.Client.MobileKinds.Domain;

public class MobileKindInventory : MasterInventory<MobileKind>
{
    public MobileKindInventory()
    {
        AddRange<MobileKindType>(e => e != MobileKindType.Unknown, e => new(e));
    }
}
