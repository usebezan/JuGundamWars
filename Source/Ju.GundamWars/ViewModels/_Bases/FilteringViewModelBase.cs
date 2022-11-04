using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Helpers;
using System;
using System.Collections.ObjectModel;


namespace Ju.GundamWars.ViewModels
{

    public abstract class FilteringViewModelBase<TDisplayViewModel> : ViewModelBase, IFilteringViewModel<TDisplayViewModel>
        where TDisplayViewModel : DisposableBindableBase, IDisplayViewModel
    {

        public FilteringViewModelBase(SerialRepository serialRepository, WindowService windowService)
            : base(windowService)
        {
            IsReady = false;

            FilteringSerials = serialRepository.Entities;

            WordFilter = new ReactivePropertySlim<string>("").AddTo(Disposables);
            SerialFilter = new ReactivePropertySlim<Serial?>().AddTo(Disposables);
            HasMemoFilter = new ReactivePropertySlim<bool>().AddTo(Disposables);

            FilteredItems = null!;
            FilteredItemsCount = new ReactivePropertySlim<int>().AddTo(Disposables);

            WordFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            SerialFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
            HasMemoFilter.Subscribe(_ => Refilter()).AddTo(Disposables);
        }


        protected bool IsReady { get; set; }
        protected virtual bool IsEmpty => string.IsNullOrEmpty(WordFilter.Value) && SerialFilter.Value == null && !HasMemoFilter.Value;

        public ObservableCollection<Serial> FilteringSerials { get; }

        public ReactivePropertySlim<string> WordFilter { get; }
        public ReactivePropertySlim<Serial?> SerialFilter { get; }
        public ReactivePropertySlim<bool> HasMemoFilter { get; }

        public IFilteredReadOnlyObservableCollection<TDisplayViewModel> FilteredItems { get; private set; }
        public ReactivePropertySlim<int> FilteredItemsCount { get; }


        public void Initialize(ReadOnlyObservableCollection<TDisplayViewModel> items)
        {
            FilteredItems = items.ToFilteredReadOnlyObservableCollection(All).AddTo(Disposables);
            IsReady = true;
        }

        public abstract void Clear();

        protected bool All(TDisplayViewModel _) =>
            true;

        protected abstract bool Filter(TDisplayViewModel viewModel);

        protected void Refilter()
        {
            if (FilteredItems == null) return;
            if (!IsReady) return;
            if (IsEmpty)
            {
                FilteredItems.Refresh(All);
            }
            else
            {
                FilteredItems.Refresh(Filter);
            }
            FilteredItemsCount.Value = FilteredItems.Count;
        }

    }

}
