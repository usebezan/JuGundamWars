using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Tags;

public class TagInventory : GwObservableCollection<TagSubject>, ITagInventory
{

    public void UncheckAll()
    {
        foreach (var item in this)
        {
            item.IsChecked = false;
        }
    }

}
