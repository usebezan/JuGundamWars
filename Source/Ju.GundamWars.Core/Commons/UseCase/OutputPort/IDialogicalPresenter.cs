using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Commons.UseCase.OutputPort;

public interface IDialogicalPresenter
{
    Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices);
}
