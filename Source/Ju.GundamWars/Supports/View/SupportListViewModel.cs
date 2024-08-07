using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportListViewModel : SupportListViewModelBase
{
    public SupportListViewModel(
        SupportInventory items,
        UnitInventory units,
        SerialInventory serials,
        SupportSlotInventory supportSlots,
        SupportBadgeInventory supportBadges,
        TagInventory tags)
        : base(items, units, serials, supportSlots, supportBadges, tags)
    {
        IsCountableChecked = true;
        IsFixedForUnitFilter = false;
    }
}
