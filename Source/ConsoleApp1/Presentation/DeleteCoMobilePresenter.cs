using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace ConsoleApp1.Presentation;

internal class DeleteCoMobilePresenter(CoMobileInventory coMobiles) : IDeletePresenter<CoMobile>
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
    public void Complete(CoMobile output)
    {
        Console.WriteLine("*** Complete ***");
        coMobiles.Remove(output);
        Console.WriteLine(output.Name);
    }
}
