using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Cuspas.View;

namespace Ju.GundamWars.Cuspas.Presentation;

internal class UpdateCuspaPresenter(
    ProgressViewModel progressViewModel,
    MessageViewModel messageViewModel,
    ViewState viewState) : IUpdatePresenter<Cuspa>
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
        messageViewModel.Message = "登録します。よろしいですか？";
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

    public void ShowProgress()
    {
        progressViewModel.IsIndeterminate = true;
        progressViewModel.Message = "Loading...?";
        viewState.DialogContent = progressViewModel;
        viewState.IsDialogOpen = true;
    }

    public void CloseProgress()
    {
        viewState.IsDialogOpen = false;
        progressViewModel.IsIndeterminate = false;
        progressViewModel.Message = string.Empty;
    }

    public void Complete(Cuspa output)
    {
        viewState.CloseEntry();
    }

}
