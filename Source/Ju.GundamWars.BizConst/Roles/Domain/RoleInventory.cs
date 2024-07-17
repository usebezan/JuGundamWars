using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.Roles.Domain;

public class RoleInventory : MasterInventory<Role>
{
    public RoleInventory()
    {
        AddRange<RoleType>(e => e != RoleType.Unknown, e => new(e));
    }
}
