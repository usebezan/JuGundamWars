using Ju.GundamWars.UseCase.Systems;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace Ju.GundamWars.Systems;

public class Dialog(AskDialogViewModel askDialogViewModel) : IDialogPresenter
{

    public async Task<bool> AskAsync(string title, string message)
    {
        askDialogViewModel.Title = title;
        askDialogViewModel.Message = message;
        var result = await DialogHost.Show(askDialogViewModel, "DialogHost");
        return result switch
        {
            bool answer => answer,
            _ => false
        };
    }

}
