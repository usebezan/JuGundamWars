using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace ConsoleApp1.Presentation;

internal class UpdateTagPresenter(
    ) : IUpdatePresenter<Tag>
{
    public void ShowProgress()
    {
        Console.WriteLine("*** ShowProgress ***");
    }
    public void CloseProgress()
    {
        Console.WriteLine("*** CloseProgress ***");
    }
    public void Initialize()
    {
        Console.WriteLine("*** Initialize ***");
    }
    public void ValidationError(string message)
    {
        Console.WriteLine("*** ValidationError ***");
        Console.WriteLine(message);
    }
    public void Cancel()
    {
        Console.WriteLine("*** Cancel ***");
    }
    public Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices)
    {
        Console.WriteLine("*** ShowMessageAsync ***");
        return Task.FromResult(MessageAnswer.Ok);
    }
    public void Complete(Tag output)
    {
        Console.WriteLine("*** Complete ***");
        Console.WriteLine($"{output.Id} {output.TagGroupText} {output.Name} {output.Order}");
    }
}
