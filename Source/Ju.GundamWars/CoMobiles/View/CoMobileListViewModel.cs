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

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : CoMobileListViewModelBase
{
    public CoMobileListViewModel(
        CoMobileInventory itemInventory,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory,
        ViewState viewState)
        : base(itemInventory, serialInventory, roleInventory, tagInventory, viewState)
    {
        IsCountableChecked = true;
        IsIdle = true;
    }


    protected override IDisposable CreateEntryViewModelAsNew() =>
        CreateEntryViewModel(EntryMode.New, new());

    protected override IDisposable CreateEntryViewModelAsEdit(CoMobile model) =>
        CreateEntryViewModel(EntryMode.Edit, model);

    protected override IDisposable CreateEntryViewModelAsCopy(CoMobile model) =>
        CreateEntryViewModel(EntryMode.Copy, model);

    private IDisposable CreateEntryViewModel(EntryMode mode, CoMobile model) =>
        new CoMobileEntryViewModel(
            mode,
            model,
            App.GetRequiredService<IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>>>(),
            App.GetRequiredService<IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>>>(),
            App.GetRequiredService<IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>>>(),
            App.GetRequiredService<ICancelEntryUseCase<CoMobile>>(),
            App.GetRequiredService<IMapper<CoMobile, CoMobile>>(),
            App.GetRequiredService<SerialInventory>(),
            App.GetRequiredService<RoleInventory>(),
            App.GetRequiredService<TagInventory>());

}
