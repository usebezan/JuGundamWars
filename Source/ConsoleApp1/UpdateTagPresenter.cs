using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace ConsoleApp1;

internal class UpdateTagPresenter(
    ) : IUpdatePresenter<Tag>
{
    public void Abort(string message)
    {
        Console.WriteLine("Abort");
        Console.WriteLine(message);
    }

    public void Cancel()
    {
        Console.WriteLine("Cancel");
    }

    public void CloseProgress()
    {
        Console.WriteLine("CloseProgress");
    }

    public void Complete(Tag output)
    {
        Console.WriteLine("Complete");
        Console.WriteLine($"{output.Id} {output.GroupText} {output.Name} {output.Order}");
    }

    public void Initialize()
    {
        Console.WriteLine("Initialize");
    }

    public Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices)
    {
        return Task.FromResult(MessageAnswer.Ok);
    }

    public void ShowProgress()
    {
        Console.WriteLine("ShowProgress");
    }

    public void ValidationError(string message)
    {
        Console.WriteLine("ValidationError");
        Console.WriteLine(message);
    }
}
