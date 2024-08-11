using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Share.Roles.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileEntryViewModel : BizEntryViewModelBase2<CoMobile>
{

    public CoMobileEntryViewModel(
        EntryMode mode,
        CoMobile model,
        IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>> insertClientUseCase,
        IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>> updateClientUseCase,
        IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>> deleteClientUseCase,
        ICancelEntryUseCase<CoMobile> cancelClientUseCase,
        IMapper<CoMobile, CoMobile> mapper,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory)
        : base(mode, model, insertClientUseCase, updateClientUseCase, deleteClientUseCase, cancelClientUseCase, mapper, tagInventory)
    {
        Serials = new(serialInventory);
        Roles = new(roleInventory) { Filter = FilterRole, };
        UpgradedCounts = [0, 1, 2, 3, 4, 5,];
    }


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

    [RelayCommand]
    private void ClearUpgraded() => Model.ClearUpgraded();

}
