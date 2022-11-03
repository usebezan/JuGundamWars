using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;


namespace Ju.GundamWars.ViewModels
{

    public abstract class DisplayViewModelBase<TModel, TEntryViewModel> : ViewModelBase, IDisplayViewModel
        where TModel : DisposableBindableBase, IModel
        where TEntryViewModel : DisposableBindableBase, IEntryViewModel
    {

        public DisplayViewModelBase(TModel model, WindowService windowService)
            : base(windowService)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));

            EditCommand = new ReactiveCommand().WithSubscribe(Edit).AddTo(Disposables);
            CopyCommand = new ReactiveCommand().WithSubscribe(Copy).AddTo(Disposables);
        }


        protected TModel Model { get; }

        public ReactiveCommand EditCommand { get; }
        public ReactiveCommand CopyCommand { get; }


        protected abstract TEntryViewModel CreateEditViewModel();
        protected abstract TEntryViewModel CreateCopyViewModel();

        private void Edit() =>
            WindowService.OpenDrawer(CreateEditViewModel());

        private void Copy() =>
            WindowService.OpenDrawer(CreateCopyViewModel());

    }

}
