using System.Collections.ObjectModel;
using Ju.GundamWars.Domain.Tags.Model;

namespace Ju.GundamWars.Tags.Domain.Model;

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
