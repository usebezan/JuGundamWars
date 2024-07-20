using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;

namespace Ju.GundamWars.CoMobiles;

public class CoMobileSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(CoMobileSubject CoMobile)
    {
        ViewModel.CoMobileSetter?.Invoke(CoMobile);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

}
