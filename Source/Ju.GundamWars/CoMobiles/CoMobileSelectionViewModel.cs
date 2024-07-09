using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoUnits;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.CoUnits;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;

namespace Ju.GundamWars.CoUnits;

public partial class CoUnitSelectionViewModel : CoUnitListViewModelBase
{

    public CoUnitSelectionViewModel(
        CoUnitSelectionController controller,
        ICoUnitInventory CoUnitInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        WindowStatus windowStatus)
        : base(CoUnitInventory, serialInventory, tagInventory)
    {
        this.controller = controller;

        Icon = GwIcon.Unknown;
        Text = GwText.Unknown;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.CoUnitSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly CoUnitSelectionController controller;

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
            Icon = GwIcon.CoUnitSuit;
            Text = GwText.CoUnitSuit;
        }
        else if (Category?.Type == CategoryType.MobileArmor)
        {
            Icon = GwIcon.CoUnitArmor;
            Text = GwText.CoUnitArmor;
        }
        else
        {
            Icon = GwIcon.Unknown;
            Text = GwText.Unknown;
        }
    }

    protected override bool Filter(object obj)
    {
        if (obj is not CoUnitSubject item) return false;
        if (!item.IsPinned) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    [RelayCommand]
    private void Select(CoUnitSubject CoUnit) => controller.Select(CoUnit);
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
