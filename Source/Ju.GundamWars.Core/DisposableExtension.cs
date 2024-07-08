namespace Ju.GundamWars;

public static class DisposableExtension
{

    public static T AddTo<T>(this T self, ICollection<IDisposable> container)
        where T : IDisposable
    {
        container.Add(self);
        return self;
    }

}
