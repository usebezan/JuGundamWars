using Ju.GundamWars.UseCase.Tags;
using System.Threading.Tasks;

namespace Ju.GundamWars.Tags;

public class TagListController(IUpdateTagsUseCase updateUseCase)
{

    public Task UpdateAsync() => updateUseCase.HandleAsync();

}
