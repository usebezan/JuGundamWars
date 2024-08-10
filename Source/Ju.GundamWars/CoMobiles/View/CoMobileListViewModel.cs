using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : CoMobileListViewModelBase
{
    public CoMobileListViewModel(
        IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>> insertClientUseCase,
        IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>> updateClientUseCase,
        IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>> deleteClientUseCase,
        ICancelEntryUseCase<CoMobile> cancelClientUseCase,
        IMapper<CoMobile, CoMobile> mapper,
        CoMobileViewState viewState,
        CoMobileInventory itemInventory,
        SerialInventory serialInventory,
        RoleInventory roleInventory,
        TagInventory tagInventory)
        : base(viewState, itemInventory, serialInventory, roleInventory, tagInventory)
    {
        IsCountableChecked = true;
        CreateEntryViewModelAsNew = () => new CoMobileEntryViewModel(EntryMode.New, new(), insertClientUseCase, updateClientUseCase, deleteClientUseCase, cancelClientUseCase, mapper, serialInventory, roleInventory, tagInventory);
        CreateEntryViewModelAsEdit = m => new CoMobileEntryViewModel(EntryMode.Edit, m, insertClientUseCase, updateClientUseCase, deleteClientUseCase, cancelClientUseCase, mapper, serialInventory, roleInventory, tagInventory);
        CreateEntryViewModelAsCopy = m => new CoMobileEntryViewModel(EntryMode.Copy, m, insertClientUseCase, updateClientUseCase, deleteClientUseCase, cancelClientUseCase, mapper, serialInventory, roleInventory, tagInventory);
    }
}
