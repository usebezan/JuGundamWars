using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Units.Domain;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotListViewModel : PilotListViewModelBase
{
    public PilotListViewModel(
        PilotInventory items,
        UnitInventory units,
        SerialInventory serials,
        PilotAbilityInventory pilotAbilities,
        PilotSkillInventory pilotSkills,
        TagInventory tags)
        : base(items, units, serials, pilotAbilities, pilotSkills, tags)
    {
        IsCountableChecked = true;
        IsFixedForUnitFilter = false;
    }
}
