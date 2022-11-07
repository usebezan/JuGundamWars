using Ju.GundamWars.Models.Services;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Options;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Diagnostics;


namespace Ju.GundamWars.ViewModels
{

    public class MainViewModel : ViewModelBase
    {

        public MainViewModel(IOptions<SystemSetting> systemSetting, WindowService windowService)
            : base(windowService)
        {
            this.systemSetting = systemSetting?.Value ?? throw new ArgumentNullException(nameof(systemSetting));

            MessageQueue = WindowService.Snackbar;
            DrawerContent = WindowService.DrawerContent;
            IsDrawerOpen = WindowService.IsDrawerOpen;

            VisitGitHubCommand = new ReactiveCommand().WithSubscribe(VisitGitHub).AddTo(Disposables);

            WindowService.Snackbar.Enqueue("Welcome to J.U Gundamu Wars!");
        }


        private readonly SystemSetting systemSetting;

        public SnackbarMessageQueue MessageQueue { get; }
        public ReadOnlyReactivePropertySlim<IEntryViewModel?> DrawerContent { get; }
        public ReactivePropertySlim<bool> IsDrawerOpen { get; }

        public ReactiveCommand VisitGitHubCommand { get; }


        private void VisitGitHub() =>
            Process.Start(new ProcessStartInfo("cmd", $"/c start {systemSetting.AppRepositoryUri}") { CreateNoWindow = true });

    }

}
