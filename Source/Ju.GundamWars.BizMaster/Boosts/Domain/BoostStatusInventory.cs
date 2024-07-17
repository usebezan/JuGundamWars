using System.Collections.ObjectModel;

namespace Ju.GundamWars.BizMaster.Boosts.Domain;

// TODO: 必要？パイロットのステータス順が変わるのでそのままでは使えない
public class BoostStatusInventory : ObservableCollection<BoostStatus>
{
}
