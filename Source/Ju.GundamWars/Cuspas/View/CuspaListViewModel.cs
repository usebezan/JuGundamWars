using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaListViewModel : CuspaListViewModelBase
{
    public CuspaListViewModel(
        CuspaInventory items,
        UnitInventory units,
        CuspaKindInventory cuspaKinds,
        BoostStatusInventory boostStatuses,
        TagInventory tags)
        : base(items, units, cuspaKinds, boostStatuses, tags)
    {
        IsCountableChecked = false;
        IsFixedForUnitFilter = false;
    }
}
