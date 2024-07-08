using System.Collections.Concurrent;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace Ju.GundamWars;

public class GwNotifiableCollection<T> : GwObservableCollection<T>
{

    public new void Add(T item)
    {
        base.Add(item);
        if (item is IGwNotifyPropertyChanged notifiable)
        {
            notifiable.PropertyChanged.Subscribe(OnItemPropertyChanged).AddTo(Disposables);
        }
    }

    // 上書きしないと基底の Add() になり購読されない
    public override void AddRange(IEnumerable<T> collection) =>
        AddRange(collection.ToList());

    // 上書きしないと基底の Add() になり購読されない
    public override void AddRange(List<T> collection) =>
        collection.ForEach(Add);

    // 上書きしないと基底の Add() になり購読されない
    public override void ReAddRange(IEnumerable<T> collection) =>
        ReAddRange(collection.ToList());

    // 上書きしないと基底の Add() になり購読されない
    public override void ReAddRange(List<T> collection)
    {
        Clear();
        AddRange(collection);
    }

    #region ==== ItemPropertyChanged ====

    private event PropertyChangedEventHandler? PrivateItemPropertyChanged;

    public IObservable<string?> ItemPropertyChanged =>
        Observable
            .FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                handler => PrivateItemPropertyChanged += handler,
                handler => PrivateItemPropertyChanged -= handler)
            .Select(x => x.EventArgs.PropertyName);

    private static readonly ConcurrentDictionary<string, PropertyChangedEventArgs> argsCache = new();

    protected void OnItemPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PrivateItemPropertyChanged?.Invoke(this, argsCache.GetOrAdd(propertyName ?? string.Empty, p => new PropertyChangedEventArgs(p)));

    #endregion

}
