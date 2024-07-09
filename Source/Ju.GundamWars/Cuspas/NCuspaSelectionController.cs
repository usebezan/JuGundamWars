using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;

namespace Ju.GundamWars.Cuspas;

public class NCuspaSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{

    public void Select(CuspaSubject cuspa)
    {
        ViewModel.NCuspaSetter?.Invoke(cuspa);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

}
