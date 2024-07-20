using Ju.GundamWars.Application.Tags.Repositories;

namespace Ju.GundamWars.Application.Tags;

public class UpdateTagsInteractor(ITagRepository repository, TagFactory factory, ITagInventory inventory) : IUpdateTagsUseCase
{

    public Task HandleAsync() =>
        repository.UpdateAsync(inventory.Select(factory.Create).ToList());

}
