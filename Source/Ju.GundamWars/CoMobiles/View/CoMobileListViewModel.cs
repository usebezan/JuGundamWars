using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : CoMobileListViewModelBase
{
    public CoMobileListViewModel(
        CoMobileInventory items,
        SerialInventory serials,
        TagInventory tags)
        : base(items, serials, tags)
    {
        IsCountableChecked = true;
    }
}
