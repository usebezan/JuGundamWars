using Ju.GundamWars.UseCase.Systems;
using MaterialDesignThemes.Wpf;

namespace Ju.GundamWars.Systems;

public class Snackbar : SnackbarMessageQueue, ISnackbarPresenter
{

    public void Show(string message) =>
        Enqueue(message, "Close", Clear);

}
