using System.Threading.Tasks;

namespace Ju.GundamWars;

public interface IEntryController<TSubject>
{
    Task InsertAsync(TSubject entry);
    Task UpdateAsync(TSubject entry);
    Task<bool> DeleteAsync(TSubject entry);
    Task<bool> CancelAsync(TSubject entry);
}
