using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Reactive.Linq;

namespace Ju.GundamWars.Cuspas;

public partial class NCuspaSelectionViewModel : CuspaListViewModelBase
{

    public NCuspaSelectionViewModel(
        NCuspaSelectionController controller,
        ICuspaInventory cuspaInventory,
        ITagInventory tagInventory,
        ICuspaKindInventory cuspaKindInventory,
        WindowStatus windowStatus)
        : base(cuspaInventory, tagInventory, cuspaKindInventory)
    {
        this.controller = controller;

        Icon = GwIcon.Cuspa;
        Text = GwText.Cuspa;

        windowStatus.PropertyChanged.Where(n => n == "SlideIndex" && windowStatus.SlideIndexType == SlideIndexType.NCuspaSelection).Subscribe(WhenSlideIndexChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly NCuspaSelectionController controller;

    [ObservableProperty]
    private string _Icon;
    [ObservableProperty]
    private string _Text;


    private void WhenSlideIndexChanged(string? _)
    {
        IsIdle = false;
        Category = controller.GetCategory();
        // FIXME: magic number
        GroupKind = 1;
        IsIdle = true;
        Refresh();
    }

    [RelayCommand]
    private void Select(CuspaSubject cuspa) => controller.Select(cuspa);
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
