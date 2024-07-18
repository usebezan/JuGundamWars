using Ju.GundamWars.BizTxn.Tags.Domain.Model;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Client.Systems.UseCase.InputPort;

public interface IUpdateAllTagsClientUseCase : IUpdateUseCase<List<Tag>>
{
}
