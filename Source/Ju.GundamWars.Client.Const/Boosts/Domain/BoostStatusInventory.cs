using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Client.Boosts.Domain;

// TODO: 必要？パイロットのステータス順が変わるのでそのままでは使えない
public class BoostStatusInventory : MasterInventory<BoostStatus>
{
    public BoostStatusInventory()
    {
        AddRange<BoostStatusType>(e => e != BoostStatusType.Unknown, e => new(e));
    }
}
