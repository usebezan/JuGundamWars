using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Helpers;
using System;


namespace Ju.GundamWars.ViewModels
{

    public abstract class ListViewModelBase<TModel, TRepository, TFilterViewModel,TEntryViewModel, TDisplayViewModel> : ViewModelBase
        where TModel : DisposableBindableBase, IModel
        where TRepository : class, IModelRepository<TModel>
        where TFilterViewModel : IFilterViewModel<TDisplayViewModel>
        where TEntryViewModel : DisposableBindableBase, IEntryViewModel
        where TDisplayViewModel : DisposableBindableBase, IDisplayViewModel
    {

        public ListViewModelBase(TRepository repository, TFilterViewModel filterViewModel, WindowService windowService)
            : base(windowService)
        {
            FilterViewModel = filterViewModel ?? throw new ArgumentNullException(nameof(filterViewModel));

            Items = repository.Models.ToReadOnlyReactiveCollection(CreateDisplayViewModel).AddTo(Disposables);

            FilterViewModel.Initialize(Items);

            NewCommand = new ReactiveCommand().WithSubscribe(New).AddTo(Disposables);
        }


        public TFilterViewModel FilterViewModel { get; }
        public ReadOnlyReactiveCollection<TDisplayViewModel> Items { get; }

        public ReactiveCommand NewCommand { get; }


        protected abstract TEntryViewModel CreateEntryViewModel();
        protected abstract TDisplayViewModel CreateDisplayViewModel(TModel model);

        private void New() =>
            WindowService.OpenDrawer(CreateEntryViewModel());

    }

}
