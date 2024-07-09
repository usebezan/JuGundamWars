using System.Collections.ObjectModel;

namespace Ju.GundamWars.Domain.Skills.Model;

public class SkillInventory : ObservableCollection<SkillSubject>
{

    public void UncheckAll()
    {
        foreach (var item in this)
        {
            item.IsChecked = false;
        }
    }

}
