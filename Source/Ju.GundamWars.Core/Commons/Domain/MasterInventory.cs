using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reactive.Linq;

namespace Ju.GundamWars.Commons.Domain;

public class MasterInventory<T> : ObservableCollection<T>
{

    public void AddRange(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public void ReAddRange(IEnumerable<T> collection)
    {
        Clear();
        AddRange(collection);
    }

    public void AddRange<TEnum>(Func<TEnum, bool> predicate, Func<TEnum, T> creator) where TEnum : Enum =>
        Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(predicate).ToList().ForEach(e => Add(creator(e)));

    #region ==== CollectionChanged ====

    public new IObservable<NotifyCollectionChangedEventArgs> CollectionChanged =>
        Observable
            .FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => base.CollectionChanged += handler,
                handler => base.CollectionChanged -= handler)
            .Select(x => x.EventArgs);

    #endregion

}
