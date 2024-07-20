using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;

namespace Ju.GundamWars.Mobiles;

public partial class MobileSelectionViewModel : MobileListViewModelBase
{

    public MobileSelectionViewModel(
        MobileSelectionController controller,
        IMobileInventory mobileInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        WindowStatus windowStatus)
        : base(mobileInventory, serialInventory, tagInventory)
    {
        this.controller = controller;

        Icon = GwIcon.Unknown;
        Text = GwText.Unknown;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.PairSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly MobileSelectionController controller;

    protected MobileSubject? Myself { get; set; }

    [ObservableProperty]
    private string _Icon;
    [ObservableProperty]
    private string _Text;


    private void WhenSlideIndexChanged(string? _)
    {
        IsIdle = false;
        Myself = controller.GetMobile();
        Category = controller.GetCategory();
        IsIdle = true;
        Refresh();

        if (Category?.Type == CategoryType.MobileSuit)
        {
            Icon = GwIcon.MobileSuit;
            Text = GwText.MobileSuit;
        }
        else if (Category?.Type == CategoryType.MobileArmor)
        {
            Icon = GwIcon.MobileArmor;
            Text = GwText.MobileArmor;
        }
        else
        {
            Icon = GwIcon.Unknown;
            Text = GwText.Unknown;
        }
    }

    protected override bool Filter(object obj)
    {
        if (obj is not MobileSubject item) return false;
        if (Myself != null && Myself.Id == item.Id) return false;
        if (!item.IsPairable) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    [RelayCommand]
    private void Select(MobileSubject mobile) => controller.Select(mobile);
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
