using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : CoMobileListViewModelBase
{
    public CoMobileListViewModel(
        CoMobileViewModel pageControllerViewModel,
        CoMobileEntryViewModel entryViewModel,
        CoMobileInventory itemInventory,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory)
        : base(pageControllerViewModel, entryViewModel, itemInventory, serialInventory, roleInventory, tagInventory)
    {
        IsCountableChecked = true;
    }
}
