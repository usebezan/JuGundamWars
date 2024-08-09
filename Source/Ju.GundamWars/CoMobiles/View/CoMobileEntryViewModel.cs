using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.CoMobiles.Domain.Service;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileEntryViewModel : BizEntryViewModelBase2<CoMobile>
{

    public CoMobileEntryViewModel(
        IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>> insertCoMobileClientUseCase,
        IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>> updateCoMobileClientUseCase,
        IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>> deleteCoMobileClientUseCase,
        CoMobileM2MMapper mapper,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory) : base(insertCoMobileClientUseCase, updateCoMobileClientUseCase, deleteCoMobileClientUseCase, mapper, tagInventory)
    {
        this.insertCoMobileClientUseCase = insertCoMobileClientUseCase;
        this.updateCoMobileClientUseCase = updateCoMobileClientUseCase;
        this.deleteCoMobileClientUseCase = deleteCoMobileClientUseCase;
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        UpgradedCounts = [0, 1, 2, 3, 4, 5,];
    }


    private readonly IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>> insertCoMobileClientUseCase;
    private readonly IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>> updateCoMobileClientUseCase;
    private readonly IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>> deleteCoMobileClientUseCase;

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

    public override Task CancelAsyncCore() =>
        Task.Run(() =>
        {
            //if (Mode == EntryMode.Edit && Origin != null)
            //{
            //    mapper.Map(Origin, Model);
            //}
        });

    [RelayCommand]
    private void ClearUpgraded() => Model.ClearUpgraded();

    [RelayCommand]
    private void UncheckAllTags() => TagInventory.UncheckAll();

}
