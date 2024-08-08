using Ju.GundamWars.Share.Tags.Domain;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Client.Tags.Domain;

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
