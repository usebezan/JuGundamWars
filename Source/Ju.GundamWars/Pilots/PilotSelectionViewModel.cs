using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;

namespace Ju.GundamWars.Pilots;

public partial class PilotSelectionViewModel : PilotListViewModelBase
{

    public PilotSelectionViewModel(
        PilotSelectionController controller,
        IPilotInventory pilotInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        IPilotAbilityInventory pilotAbilityInventory,
        IPilotSkillInventory pilotSkillInventory,
        WindowStatus windowStatus)
        : base(pilotInventory, serialInventory, tagInventory, pilotAbilityInventory, pilotSkillInventory)
    {
        this.controller = controller;

        Icon = GwIcon.Pilot;
        Text = GwText.Pilot;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.PilotSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly PilotSelectionController controller;

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
    }

    protected override bool Filter(object obj)
    {
        if (obj is not PilotSubject item) return false;
        if (!item.IsPinned) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    [RelayCommand]
    private void Select(PilotSubject pilot) => controller.Select(pilot);
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
