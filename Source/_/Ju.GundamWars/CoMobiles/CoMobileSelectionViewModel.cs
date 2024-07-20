using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;

namespace Ju.GundamWars.CoMobiles;

public partial class CoMobileSelectionViewModel : CoMobileListViewModelBase
{

    public CoMobileSelectionViewModel(
        CoMobileSelectionController controller,
        ICoMobileInventory CoMobileInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        WindowStatus windowStatus)
        : base(CoMobileInventory, serialInventory, tagInventory)
    {
        this.controller = controller;

        Icon = GwIcon.Unknown;
        Text = GwText.Unknown;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.CoMobileSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly CoMobileSelectionController controller;

    [ObservableProperty]
    private string _Icon;
    [ObservableProperty]
    private string _Text;


    private void WhenSlideIndexChanged(string? _)
    {
        IsIdle = false;
        Category = controller.GetCategory();
        IsIdle = true;
        Refresh();

        if (Category?.Type == CategoryType.MobileSuit)
        {
            Icon = GwIcon.CoMobileSuit;
            Text = GwText.CoMobileSuit;
        }
        else if (Category?.Type == CategoryType.MobileArmor)
        {
            Icon = GwIcon.CoMobileArmor;
            Text = GwText.CoMobileArmor;
        }
        else
        {
            Icon = GwIcon.Unknown;
            Text = GwText.Unknown;
        }
    }

    protected override bool Filter(object obj)
    {
        if (obj is not CoMobileSubject item) return false;
        if (!item.IsPinned) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    [RelayCommand]
    private void Select(CoMobileSubject CoMobile) => controller.Select(CoMobile);
    [RelayCommand]
    private void Cancel() => controller.Cancel();

    [RelayCommand]
    private void Clear()
    {
        IsIdle = false;
        ClearCore();
        IsIdle = true;
        Refresh();
    }

}
