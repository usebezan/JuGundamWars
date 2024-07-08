using System.Collections;

namespace Ju.GundamWars.UseCase;

public interface IInventory : IList
{
    object LockObj { get; }
}

public interface IInventory<T> : IList<T>, IInventory
{
    void AddRange(IEnumerable<T> collection);
    void AddRange(List<T> collection);
    void ReAddRange(IEnumerable<T> collection);
    void ReAddRange(List<T> collection);
}
