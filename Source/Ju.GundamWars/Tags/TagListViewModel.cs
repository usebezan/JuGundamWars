using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Tags;

public partial class TagListViewModel : GwObservableObject
{

    public TagListViewModel(TagListController controller, ITagInventory tagInventory, WindowStatus windowStatus)
    {
        this.windowStatus = windowStatus;
        this.controller = controller;

        MobileTags = new(tagInventory) { Filter = FilterMobileTag, };
        BattleshipTags = new(tagInventory) { Filter = FilterBattleshipTag, };
        PilotTags = new(tagInventory) { Filter = FilterPilotTag, };
        SupportTags = new(tagInventory) { Filter = FilterSupportTag, };
        CuspaTags = new(tagInventory) { Filter = FilterCuspaTag, };
        CoUnitTags = new(tagInventory) { Filter = FilterCoUnitTag, };

        windowStatus.PropertyChanged.Where(n => n == "TabIndex").Subscribe(WhenTabIndexChanged).AddTo(Disposables);
    }


    private readonly WindowStatus windowStatus;
    private readonly TagListController controller;

    private bool isActived;

    public ListCollectionView MobileTags { get; }
    public ListCollectionView BattleshipTags { get; }
    public ListCollectionView PilotTags { get; }
    public ListCollectionView SupportTags { get; }
    public ListCollectionView CuspaTags { get; }
    public ListCollectionView CoUnitTags { get; }

    private async void WhenTabIndexChanged(string? _)
    {
        if (windowStatus.TabIndexType == TabIndexType.Tag)
        {
            isActived = true;
        }
        else if (isActived)
        {
            await controller.UpdateAsync();
            isActived = false;
        }
    }

    private bool FilterMobileTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForMobile();
    }

    private bool FilterBattleshipTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForBattleship();
    }

    private bool FilterPilotTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForPilot();
    }

    private bool FilterSupportTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForSupport();
    }

    private bool FilterCuspaTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForCuspa();
    }

    private bool FilterCoUnitTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForCoUnit();
    }

}
