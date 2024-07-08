using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Mobiles;
using System.Collections.Generic;

namespace Ju.GundamWars.Supports;

public class SupportSelectionController(MobileEntryViewModel viewModel, WindowStatus windowStatus) : SelectionControllerBase(viewModel, windowStatus)
{
    public void Select(SupportSubject support)
    {
        ViewModel.SupportSetter?.Invoke(support);
        WindowStatus.SlideIndexType = SlideIndexType.MobileEntry;
    }

    public List<Serial> GetMobileSerials()
    {
        var list = new List<Serial>();
        if (ViewModel.Entry.Serial != null)
        {
            list.Add(ViewModel.Entry.Serial);
        }
        foreach (var sub in ViewModel.Entry.SubSerials)
        {
            list.Add(sub);
        }
        return list;
    }

}
