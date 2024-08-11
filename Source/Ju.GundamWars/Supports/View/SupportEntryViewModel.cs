using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Client.Supports.Domain.Service;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportEntryViewModel : BizEntryViewModelBase<Support>
{

    public SupportEntryViewModel(
        SupportM2MMapper mapper,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory) : base(tagInventory)
    {
        this.mapper = mapper;
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        UpgradedCounts = [0, 1, 2, 3, 4, 5,];
    }


    private readonly SupportM2MMapper mapper;

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
        return item.TagGroupType.ForSupport();
    }

    public override Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            Mode = Commons.Domain.EntryMode.New;
            Model = new();
            Origin = null;
            ResetTags(Model);
        });

    public override Task OpenEntryAsEditAsync(Support model) =>
        Task.Run(() =>
        {
            Mode = Commons.Domain.EntryMode.Edit;
            Model = model;
            Origin = mapper.Map(model, new());
            ResetTags(Model);
        });

    public override Task OpenEntryAsCopyAsync(Support model) =>
        Task.Run(() =>
        {
            Mode = Commons.Domain.EntryMode.Copy;
            Model = mapper.Map(model, new());
            Origin = null;
            ResetTags(Model);
        });

    public override Task CancelAsync()
    {
        throw new NotImplementedException();
    }

    public override Task EnterAsync()
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

}
