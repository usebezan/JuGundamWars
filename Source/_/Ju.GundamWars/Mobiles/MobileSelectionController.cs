using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles.Domain;

namespace Ju.GundamWars.Mobiles;

public class MobileSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(MobileSubject mobile)
    {
        ViewModel.PairSetter?.Invoke(mobile);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

    public MobileSubject? GetMobile() => ViewModel.Entry;

}
