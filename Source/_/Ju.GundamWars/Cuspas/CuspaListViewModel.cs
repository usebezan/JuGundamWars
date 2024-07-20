using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.Windows.Data;

namespace Ju.GundamWars.Cuspas;

public partial class CuspaListViewModel : CuspaListViewModelBase
{

    public CuspaListViewModel(
        CuspaListController controller,
        ICuspaInventory cuspaInventory,
        ICategoryInventory categoryInventory,
        ITagInventory tagInventory,
        ICuspaKindInventory cuspaKindInventory)
        : base(cuspaInventory, tagInventory, cuspaKindInventory)
    {
        this.controller = controller;

        Inventory = cuspaInventory;
        Categories = new(categoryInventory) { Filter = FilterCategory, };

        IsIdle = true;
    }


    private readonly CuspaListController controller;

    public ICuspaInventory Inventory { get; }
    public ListCollectionView Categories { get; }


    private bool FilterCategory(object obj)
    {
        if (obj is not Category item) return false;
        return item.Type.ForCuspa();
    }

    [RelayCommand]
    private void OpenEntryAsNew() => controller.OpenEntryAsNew();
    [RelayCommand]
    private void OpenEntryAsEdit(CuspaSubject cuspa) => controller.OpenEntryAsEdit(cuspa);
    [RelayCommand]
    private void OpenEntryAsCopy(CuspaSubject cuspa) => controller.OpenEntryAsCopy(cuspa);

    [RelayCommand]
    private void Clear()
    {
        IsIdle = false;
        ClearCore();
        Category = null;
        GroupKind = null;
        IsIdle = true;
        Refresh();
    }

}
