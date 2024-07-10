using Ju.GundamWars.Biz.Tags.Domain.Model;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Biz.Tags.Domain.Inventory;

public class TagInventory : ObservableCollection<Tag>
{

    public void UncheckAll()
    {
        foreach (var item in this)
        {
            item.IsChecked = false;
        }
    }

}
