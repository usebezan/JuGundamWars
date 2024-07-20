using Ju.GundamWars.Const;

namespace Ju.GundamWars;

public interface IEntryViewModel<TSubject>
{
    void SetEntry(EntryMode mode, TSubject entry);
}
