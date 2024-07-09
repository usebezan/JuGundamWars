using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;
using Ju.GundamWars.Pilots.Domain;

namespace Ju.GundamWars.Pilots;

public class PilotSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(PilotSubject pilot)
    {
        ViewModel.PilotSetter?.Invoke(pilot);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

}
