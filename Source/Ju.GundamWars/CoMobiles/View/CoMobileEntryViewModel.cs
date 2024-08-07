using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileEntryViewModel : BizEntryViewModelBase<CoMobile>
{

    public CoMobileEntryViewModel(
        CoMobileM2MMapper mapper,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory) : base(tagInventory)
    {
        this.mapper = mapper;
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        UpgradedCounts = [0, 1, 2, 3, 4, 5,];
    }


    private readonly CoMobileM2MMapper mapper;

    public ListCollectionView Serials { get; }
    public ListCollectionView Roles { get; }
    public List<int> UpgradedCounts { get; }


    private bool FilterRole(object obj)
    {
        if (obj is not Role item) return false;
        return item.Type.ForMobileSuit();
    }

    protected override bool FilterTag(object obj)
    {
        if (obj is not Tag item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.TagGroupType.ForCoMobile();
    }

    public override Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            Mode = EntryMode.New;
            Model = new();
            Origin = null;
            ResetTags(Model);
        });

    public override Task OpenEntryAsEditAsync(CoMobile model) =>
        Task.Run(() =>
        {
            Mode = EntryMode.Edit;
            Model = model;
            Origin = mapper.Map(model, new());
            ResetTags(Model);
        });

    public override Task OpenEntryAsCopyAsync(CoMobile model) =>
        Task.Run(() =>
        {
            Mode = EntryMode.Copy;
            Model = mapper.Map(model, new());
            Origin = null;
            ResetTags(Model);
        });

    public override Task CancelAsync() =>
        Task.Run(() =>
        {
            if (Mode == EntryMode.Edit && Origin != null)
            {
                mapper.Map(Origin, Model);
            }
        });

    [RelayCommand]
    private void ResetUpgraded() => Model.ResetUpgraded();

}
