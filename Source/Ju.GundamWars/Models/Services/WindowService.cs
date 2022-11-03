using Ju.GundamWars.ViewModels;
using Ju.GundamWars.Views;
using MaterialDesignThemes.Wpf;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Reactive.Subjects;
using System.Threading.Tasks;


namespace Ju.GundamWars.Models.Services
{

    public class WindowService : DisposableBindableBase
    {

        public WindowService(MessageDialogViewModel messageDialogViewModel, YesNoDialog yesNoDialog)
        {
            Snackbar = new SnackbarMessageQueue().AddTo(Disposables);

            this.messageDialogViewModel = messageDialogViewModel;
            this.yesNoDialog = yesNoDialog;

            drawerContentSource = new Subject<IEntryViewModel?>().AddTo(Disposables);
            DrawerContent = drawerContentSource.DisposePreviousValue().ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            IsDrawerOpen = new ReactivePropertySlim<bool>().AddTo(Disposables);
        }


        #region Snackbar

        public SnackbarMessageQueue Snackbar { get; }

        #endregion

        #region Dialog

        public static string DialogIdentifier => "DialogHost";


        private readonly MessageDialogViewModel messageDialogViewModel;
        private readonly YesNoDialog yesNoDialog;


        public Task<bool> QuestionAsync(string message) =>
            QuestionAsync(message, "Alert");

        public async Task<bool> QuestionAsync(string message, string iconKind)
        {
            messageDialogViewModel.IconKind.Value = iconKind;
            messageDialogViewModel.Message.Value = message;
            var result = await DialogHost.Show(yesNoDialog, DialogIdentifier);
            return (result is bool isAccept) && isAccept;
        }

        #endregion

        #region Drawer

        private readonly Subject<IEntryViewModel?> drawerContentSource;

        public ReadOnlyReactivePropertySlim<IEntryViewModel?> DrawerContent { get; }
        public ReactivePropertySlim<bool> IsDrawerOpen { get; }


        public async void OpenDrawer(IEntryViewModel viewModel)
        {
            if (IsDrawerOpen.Value)
            {
                var isAccept = await CloseDrawerAsync();
                if (!isAccept) return;
            }
            drawerContentSource.OnNext(viewModel);
            IsDrawerOpen.Value = true;
        }

        public void CloseDrawer()
        {
            IsDrawerOpen.Value = false;
            drawerContentSource.OnNext(null);
        }

        public async Task<bool> CloseDrawerAsync()
        {
            if (DrawerContent.Value?.IsDirty ?? false)
            {
                if (DrawerContent.Value.IsAdd)
                {
                    var isAccept = await QuestionAsync("Are you sure you want to 'CLOSE' without Adding?");
                    if (!isAccept) return false;
                }
                else
                {
                    var isAccept = await QuestionAsync("Are you sure you want to 'CLOSE' without Saving Changes?");
                    if (!isAccept) return false;
                    DrawerContent.Value.Reload();
                }
            }

            IsDrawerOpen.Value = false;
            drawerContentSource.OnNext(null);
            return true;
        }

        #endregion

    }

}
