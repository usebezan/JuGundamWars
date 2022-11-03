using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Ju.GundamWars.ViewModels
{

    public abstract class EntryViewModelBase<TModel> : ViewModelBase, IEntryViewModel
        where TModel : DisposableBindableBase, IModel
    {

        public EntryViewModelBase(EntryType type, TModel model, SerialRepository serialRepository, WindowService windowService)
            : base(windowService)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));

            Type = type;

            OptionalSerials = serialRepository.Entities;

            AddCommand = new AsyncReactiveCommand().WithSubscribe(Add).AddTo(Disposables);
            RemoveCommand = new AsyncReactiveCommand().WithSubscribe(Remove).AddTo(Disposables);
            SaveCommand = new AsyncReactiveCommand().WithSubscribe(Save).AddTo(Disposables);
            CancelCommand = new AsyncReactiveCommand().WithSubscribe(Cancel).AddTo(Disposables);

            if (IsAdd)
            {
                // コレクションに追加した際にモデルが生成されるので、登録用のモデルは破棄する
                Model.AddTo(Disposables);
            }
        }


        protected TModel Model { get; }

        public abstract string Title { get; }
        public abstract string IconKind { get; }
        public EntryType Type { get; }
        public bool IsAdd => Type == EntryType.Add || Type == EntryType.Copy;
        public bool IsEdit => Type == EntryType.Edit;
        public int Index => Type == EntryType.Add ? 0 : 1;
        public bool IsDirty => Model.IsDirty();

        public abstract ReadOnlyReactivePropertySlim<bool> HasErrors { get; }

        public ObservableCollection<Serial> OptionalSerials { get; }

        public AsyncReactiveCommand AddCommand { get; }
        public AsyncReactiveCommand RemoveCommand { get; }
        public AsyncReactiveCommand SaveCommand { get; }
        public AsyncReactiveCommand CancelCommand { get; }


        protected virtual async Task Add()
        {
            if (!IsAdd) throw new InvalidOperationException();

            if (HasErrors.Value)
            {
                // TODO: message
                WindowService.Snackbar.Enqueue("Has errors!");
                return;
            }

            var isAccept = await WindowService.QuestionAsync("Are you sure you want to 'ADD'?");
            if (!isAccept) return;

            Model.Insert();
            WindowService.CloseDrawer();
        }

        protected virtual async Task Remove()
        {
            if (!IsEdit) throw new InvalidOperationException();

            var isAccept = await WindowService.QuestionAsync("Are you sure you want to 'REMOVE'?");
            if (!isAccept) return;

            Model.Delete();
            WindowService.CloseDrawer();
        }

        protected virtual async Task Save()
        {
            if (!IsEdit) throw new InvalidOperationException();

            if (HasErrors.Value)
            {
                // TODO: message
                WindowService.Snackbar.Enqueue("Has errors!");
                return;
            }

            var isAccept = await WindowService.QuestionAsync("Are you sure you want to 'SAVE'?");
            if (!isAccept) return;

            Model.Update();
            WindowService.CloseDrawer();
        }

        protected virtual async Task Cancel() =>
            await WindowService.CloseDrawerAsync();

        public void Reload() =>
            Model.Reload();

    }

}
