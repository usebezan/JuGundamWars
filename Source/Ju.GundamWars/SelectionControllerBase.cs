using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;

namespace Ju.GundamWars;

public abstract class SelectionControllerBase(MobileEntryViewModel viewModel, WindowStatus windowStatus)
{

    protected readonly MobileEntryViewModel ViewModel = viewModel;
    protected readonly WindowStatus WindowStatus = windowStatus;


    public Category? GetCategory() => ViewModel.Entry?.Category;
    public void Cancel() => WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;

}
