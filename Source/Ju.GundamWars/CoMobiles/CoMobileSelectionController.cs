using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;

namespace Ju.GundamWars.CoMobiles;

public class CoUnitSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(CoUnitSubject CoUnit)
    {
        ViewModel.CoUnitSetter?.Invoke(CoUnit);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

}
