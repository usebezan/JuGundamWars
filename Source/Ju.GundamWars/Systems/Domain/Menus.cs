using Ju.GundamWars.Systems.View;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Systems.Domain;

internal class Menus : ObservableCollection<MenuItemViewModel>
{
    public Menus()
    {
        Add(new() { Icon = GwIcon.Mobile, Text = GwText.Mobile, });
        Add(new() { Icon = GwIcon.Pilot, Text = GwText.Pilot, });
        Add(new() { Icon = GwIcon.Support, Text = GwText.Support, });
        Add(new() { Icon = GwIcon.CoMobile, Text = GwText.CoMobile, });
        Add(new() { Icon = GwIcon.Cuspa, Text = GwText.Cuspa, });
        Add(new() { Icon = GwIcon.Tag, Text = GwText.Tag, });
    }
}
