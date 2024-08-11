using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Commons.Presentation;

internal class CancelEntryPresenter(MessageViewModel messageViewModel, ViewState viewState)
    : ICancelEntryPresenter
{

    public void Initialize()
    {
        viewState.CloseDialog();
    }

    public void ValidationError(string message)
    {
    }

    public async Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices)
    {
        messageViewModel.Message = "変更された内容を保存せずに閉じます。よろしいですか？";
        messageViewModel.Type = choices;
        viewState.OpenDialog(messageViewModel);
        var result = await messageViewModel.GetAnswerAsync();
        viewState.CloseDialog();
        return result;
    }

    public void Cancel()
    {
    }

    public void Complete()
    {
        viewState.CloseEntry();
    }

}
