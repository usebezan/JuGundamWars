using Ju.GundamWars.CoMobiles.View;
using Ju.GundamWars.Cuspas.View;
using Ju.GundamWars.Mobiles.View;
using Ju.GundamWars.Pilots.View;
using Ju.GundamWars.Supports.View;
using Ju.GundamWars.Systems.View;
using Ju.GundamWars.Tags.View;
using System.Collections.ObjectModel;

namespace Ju.GundamWars.Systems.Domain;

internal class Menus : ObservableCollection<MenuItemViewModel>
{
    public Menus(
        CoMobileListViewModel coMobileListViewModel,
        CuspaListViewModel cuspaListViewModel,
        MobileListViewModel mobileListViewModel,
        PilotListViewModel pilotListViewModel,
        SupportListViewModel supportListViewModel,
        TagListViewModel tagListViewModel)
    {
        Add(new() { Icon = GwIcon.Mobile, Text = GwText.Mobile, Content = mobileListViewModel, });
        Add(new() { Icon = GwIcon.Pilot, Text = GwText.Pilot, Content = pilotListViewModel, });
        Add(new() { Icon = GwIcon.Support, Text = GwText.Support, Content = supportListViewModel, });
        Add(new() { Icon = GwIcon.CoMobile, Text = GwText.CoMobile, Content = coMobileListViewModel, });
        Add(new() { Icon = GwIcon.Cuspa, Text = GwText.Cuspa, Content = cuspaListViewModel, });
        Add(new() { Icon = GwIcon.Tag, Text = GwText.Tag, Content = tagListViewModel, });
    }
}
