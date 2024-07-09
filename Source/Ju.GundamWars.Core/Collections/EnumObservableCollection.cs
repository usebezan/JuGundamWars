using System.Collections.ObjectModel;

namespace Ju.GundamWars.Collections;

public class EnumObservableCollection<T> : ObservableCollection<T>
{

    public void AddRange<TEnum>(Func<TEnum, bool> predicate, Func<TEnum, T> creator) where TEnum : Enum =>
        Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Where(predicate).ToList().ForEach(e => Add(creator(e)));

}
