using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Helpers;
using System;


namespace Ju.GundamWars.ViewModels
{

    public abstract class ListViewModelBase<TModel, TRepository, TFilteringViewModel, TEntryViewModel, TDisplayViewModel> : ViewModelBase
        where TModel : DisposableBindableBase, IModel
        where TRepository : class, IModelRepository<TModel>
        where TFilteringViewModel : IFilteringViewModel<TDisplayViewModel>
        where TEntryViewModel : DisposableBindableBase, IEntryViewModel
        where TDisplayViewModel : DisposableBindableBase, IDisplayViewModel
    {

        public ListViewModelBase(TRepository repository, TFilteringViewModel filteringViewModel, WindowService windowService)
            : base(windowService)
        {
            Filtering = filteringViewModel ?? throw new ArgumentNullException(nameof(filteringViewModel));

            Items = repository.Models.ToReadOnlyReactiveCollection(CreateDisplayViewModel).AddTo(Disposables);

            Filtering.Initialize(Items);

            NewCommand = new ReactiveCommand().WithSubscribe(New).AddTo(Disposables);
        }


        public TFilteringViewModel Filtering { get; }
        public ReadOnlyReactiveCollection<TDisplayViewModel> Items { get; }

        public ReactiveCommand NewCommand { get; }


        protected abstract TEntryViewModel CreateEntryViewModel();
        protected abstract TDisplayViewModel CreateDisplayViewModel(TModel model);

        private void New() =>
            WindowService.OpenDrawer(CreateEntryViewModel());

    }

}
