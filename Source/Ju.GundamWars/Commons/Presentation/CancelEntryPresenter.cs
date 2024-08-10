using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.CoMobiles.View;

namespace Ju.GundamWars.Commons.Presentation;

internal class CancelEntryPresenter(CoMobileViewState coMobileViewState, MessageViewModel messageViewModel, ViewState viewState) : ICancelEntryPresenter
{

    public void Initialize()
    {
        viewState.IsDialogOpen = false;
    }

    public void ValidationError(string message)
    {
        Console.WriteLine("*** ValidationError ***");
        Console.WriteLine(message);
    }

    public async Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices)
    {
        messageViewModel.Message = "保存せずに閉じます。よろしいですか？";
        messageViewModel.Type = choices;
        viewState.DialogContent = messageViewModel;
        viewState.IsDialogOpen = true;
        var result = await messageViewModel.GetAnswerAsync();
        viewState.IsDialogOpen = false;
        return result;
    }

    public void Cancel()
    {
        Console.WriteLine("*** Cancel ***");
    }

    public void Complete()
    {
        coMobileViewState.PageIndexType = PageIndexType.List;
    }

}
