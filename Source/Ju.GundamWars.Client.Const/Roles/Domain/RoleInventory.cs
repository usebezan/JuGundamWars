using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Roles.Domain;

namespace Ju.GundamWars.Client.Roles.Domain;

public class RoleInventory : MasterInventory<Role>
{
    public RoleInventory()
    {
        AddRange<RoleType>(e => e != RoleType.Unknown, e => new(e));
    }
}
