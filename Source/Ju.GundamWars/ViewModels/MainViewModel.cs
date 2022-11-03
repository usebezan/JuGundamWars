using Ju.GundamWars.Models.Services;
using MaterialDesignThemes.Wpf;
using Reactive.Bindings;
using System;


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

            WindowService.Snackbar.Enqueue("Welcome to J.U Gundamu Wars!");
        }


        public SnackbarMessageQueue MessageQueue { get; }
        public ReadOnlyReactivePropertySlim<IEntryViewModel?> DrawerContent { get; }
        public ReactivePropertySlim<bool> IsDrawerOpen { get; }

    }

}
