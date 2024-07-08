using Ju.GundamWars.Domain.Tags;

namespace Ju.GundamWars.UseCase.Tags;

public interface ITagInventory : IInventory<TagSubject>
{
    void UncheckAll();
}
