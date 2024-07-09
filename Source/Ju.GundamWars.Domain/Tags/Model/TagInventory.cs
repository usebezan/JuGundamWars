using System.Collections.ObjectModel;

namespace Ju.GundamWars.Domain.Tags.Model;

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
