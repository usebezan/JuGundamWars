using System.Collections.ObjectModel;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Inventory;

public class TagInventory : ObservableCollection<TagSubject>
{

    public void UncheckAll()
    {
        foreach (var item in this)
        {
            item.IsChecked = false;
        }
    }

}
