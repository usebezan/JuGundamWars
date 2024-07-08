using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;
using System.Threading.Tasks;

namespace Ju.GundamWars.Systems;

public class EnterPresenter(WindowStatus windowStatus, IDialogPresenter dialog, ISnackbarPresenter snackbar) : IEnterPresenter
{

    public Task<bool> AskAsync(string title, string message) =>
        dialog.AskAsync(title, message);

    public void Cancel() =>
        windowStatus.SlideIndexType = SlideIndexType.Main;

    public void Abort(string message)
    {
        snackbar.Show(message);
    }

    public void Complete(string message)
    {
        windowStatus.SlideIndexType = SlideIndexType.Main;
        snackbar.Show(message);
    }

}
