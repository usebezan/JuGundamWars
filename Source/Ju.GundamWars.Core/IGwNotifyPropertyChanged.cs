namespace Ju.GundamWars;

public interface IGwNotifyPropertyChanged
{
    IObservable<string?> PropertyChanged { get; }
}
