using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace Ju.GundamWars.Supports;

public partial class SupportSelectionViewModel : SupportListViewModelBase
{

    public SupportSelectionViewModel(
        SupportSelectionController controller,
        ISupportInventory supportInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        IBoostInventory boostInventory,
        ISupportSlotInventory supportSlotInventory,
        ISupportBadgeInventory supportBadgeInventory,
        WindowStatus windowStatus)
        : base(supportInventory, serialInventory, tagInventory, boostInventory, supportSlotInventory, supportBadgeInventory)
    {
        this.controller = controller;

        MobileSerials = [];

        Icon = GwIcon.Support;
        Text = GwText.Support;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.SupportSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly SupportSelectionController controller;

    protected List<Serial> MobileSerials { get; }

    [ObservableProperty]
    private string _Icon;
    [ObservableProperty]
    private string _Text;


    private void WhenSlideIndexChanged(string? _)
    {
        IsIdle = false;
        MobileSerials.Clear();
        MobileSerials.AddRange(controller.GetMobileSerials());
        Category = controller.GetCategory();
        IsIdle = true;
        Refresh();
    }

    protected override bool Filter(object obj)
    {
        if (obj is not SupportSubject item) return false;
        if (!item.IsPinned) return false;
        if (MobileSerials.Count != 0 &&
            item.LimitedSerials.Count != 0 &&
            !MobileSerials.Any(s => s.Id == item.Serial?.Id) &&
            !MobileSerials.Any(s => item.LimitedSerials.Any(l => s.Id == l.Id))) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    [RelayCommand]
    private void Select(SupportSubject support) => controller.Select(support);
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
