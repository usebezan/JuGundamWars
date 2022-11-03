using Ju.GundamWars.Models.Services;
using MaterialDesignThemes.Wpf;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Diagnostics;


namespace Ju.GundamWars.ViewModels
{

    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(WindowService windowService)
            : base(windowService)
        {
            MessageQueue = WindowService.Snackbar;
            DrawerContent = WindowService.DrawerContent;
            IsDrawerOpen = WindowService.IsDrawerOpen;

            VisitGitHubCommand = new ReactiveCommand().WithSubscribe(VisitGitHub).AddTo(Disposables);

            WindowService.Snackbar.Enqueue("Welcome to J.U Gundamu Wars!");
        }


        public SnackbarMessageQueue MessageQueue { get; }
        public ReadOnlyReactivePropertySlim<IEntryViewModel?> DrawerContent { get; }
        public ReactivePropertySlim<bool> IsDrawerOpen { get; }

        public ReactiveCommand VisitGitHubCommand { get; }


        private void VisitGitHub() =>
            Process.Start(new ProcessStartInfo("cmd", $"/c start https://github.com/usebezan/JuGundamWars") { CreateNoWindow = true });

    }

}
