using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;
using System;
using System.Threading.Tasks;

namespace Ju.GundamWars.Systems;

public class Progress(ProgressViewModel viewModel, WindowStatus windowStatus, ISnackbarPresenter snackbar) : IProgressPresenter
{

    private async void Complete(string snackbarMessage, string statusbarMessage, string statusBarIcon)
    {
        viewModel.Value = viewModel.Maximum;
        viewModel.Message = "Completed.";
        await Task.Delay(500);
        windowStatus.StatusbarIcon = statusBarIcon;
        windowStatus.StatusbarMessage = statusbarMessage;
        windowStatus.SlideIndexType = SlideIndexType.Main;
        snackbar.Show(snackbarMessage);
    }

    public async void Initialize(int maximum)
    {
        windowStatus.StatusbarIcon = GwIcon.Information;
        windowStatus.StatusbarMessage = "Loading...";
        windowStatus.SlideIndexType = SlideIndexType.Progress;
        viewModel.Icon = "RobotIndustrial";
        viewModel.Title = "Processing...";
        viewModel.Value = 0;
        viewModel.Maximum = maximum;
        viewModel.Message = string.Empty;
        await Task.Delay(500);
    }

    public void ShowMessage(string message) =>
       viewModel.Message = message;

    public void Increment() =>
       viewModel.Value += 1;

    public void Increment(Action action)
    {
        action();
        Increment();
    }

    public T Increment<T>(Func<T> func)
    {
        var ret = func();
        Increment();
        return ret;
    }

    public void Increment(string message)
    {
        ShowMessage(message);
        Increment();
    }

    public void Increment(string message, Action action)
    {
        ShowMessage(message);
        action();
        Increment();
    }

    public T Increment<T>(string message, Func<T> func)
    {
        ShowMessage(message);
        var ret = func();
        Increment();
        return ret;
    }

    public void Complete(string snackbarMessage) =>
        Complete(snackbarMessage, "Ready", GwIcon.Information);

    public void CompleteWithWarning(string snackbarMessage, string statusbarMessage) =>
        Complete(snackbarMessage, statusbarMessage, GwIcon.Warning);

}
