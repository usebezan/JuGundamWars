using Ju.GundamWars.Application.Tags.Repositories;
using Ju.GundamWars.Domain.Tags.Factories;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Application.Tags;

public class UpdateTagsInteractor(ITagRepository repository, TagFactory factory, ITagInventory inventory) : IUpdateTagsUseCase
{

    public Task HandleAsync() =>
        repository.UpdateAsync(inventory.Select(factory.Create).ToList());

}
