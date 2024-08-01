using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share._TODO.Categories.Domain;
using Ju.GundamWars.Share.Tags.Domain;

namespace Ju.GundamWars.Cuspas.Domain;

internal abstract partial class CuspaList : BizListBase<Cuspa>
{

    public CuspaList(
        CuspaInventory items,
        TagInventory tags)
        : base(items, tags)
    {
        IsIdle = true;
    }


    [ObservableProperty]
    private bool _HasMemoFilter = false;
    [ObservableProperty]
    private bool _HasNoMobileFilter = false;


    partial void OnHasMemoFilterChanged(bool value) => Refresh();
    partial void OnHasNoMobileFilterChanged(bool value) => Refresh();

    protected override bool FilterItem(object obj)
    {
        if (obj is not Cuspa item) return false;
        if (TagFilter != null && !item.Tags.Any(i => i.Id == TagFilter.Id)) return false;
        if (HasMemoFilter && !item.HasMemo) return false;
        // TODO: if (HasNoMobileFilter && item.Mobile != null) return false;
        return true;
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCuspa();
    }

    public override void FilterClear()
    {
        IsIdle = false;
        TagFilter = null;
        HasMemoFilter = false;
        HasNoMobileFilter = false;
        IsIdle = true;
        Refresh();
    }

}
