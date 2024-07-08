using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;

namespace Ju.GundamWars.Cuspas;

public class SCuspaSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(CuspaSubject cuspa)
    {
        ViewModel.SCuspaSetter?.Invoke(cuspa);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

}
