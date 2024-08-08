using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

public partial class MessageViewModel : ModelBase
{

    private TaskCompletionSource<MessageAnswer> answer = null!;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsCancelVisible))]
    [NotifyPropertyChangedFor(nameof(IsOkVisible))]
    [NotifyPropertyChangedFor(nameof(IsYesVisible))]
    [NotifyPropertyChangedFor(nameof(IsNoVisible))]
    private MessageAnswer __Type = MessageAnswer.Ok;

    [ObservableProperty]
    private string __Message = string.Empty;

    public bool IsCancelVisible => Type.HasFlag(MessageAnswer.Cancel);
    public bool IsOkVisible => Type.HasFlag(MessageAnswer.Ok);
    public bool IsYesVisible => Type.HasFlag(MessageAnswer.Yes);
    public bool IsNoVisible => Type.HasFlag(MessageAnswer.No);


    public Task<MessageAnswer> GetAnswerAsync()
    {
        answer = new();
        return answer.Task;
    }

    [RelayCommand]
    public void Cancel() =>
        answer.SetResult(MessageAnswer.Cancel);

    [RelayCommand]
    public void Ok() =>
        answer.SetResult(MessageAnswer.Ok);

    [RelayCommand]
    public void Yes() =>
        answer.SetResult(MessageAnswer.Yes);

    [RelayCommand]
    public void No() =>
        answer.SetResult(MessageAnswer.No);

}
