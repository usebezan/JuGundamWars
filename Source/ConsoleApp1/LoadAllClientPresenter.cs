using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;

namespace ConsoleApp1;

internal class LoadAllClientPresenter : ILoadAllClientPresenter
{
    public void ShowProgress()
    {
    }
    public void CloseProgress()
    {
    }
    public void Complete(DataModels output)
    {
        //Console.WriteLine("PilotAbilities");
        //foreach (var item in output.PilotAbilities)
        //{
        //    Console.WriteLine(item.ToString());
        //}

        //Console.WriteLine("Serials");
        //foreach (var item in output.Serials)
        //{
        //    Console.WriteLine(item.ToString());
        //}

        //Console.WriteLine("Skills");
        //foreach (var item in output.Skills)
        //{
        //    Console.WriteLine(item.ToString());
        //}

        Console.WriteLine("SupportBadges");
        foreach (var item in output.SupportBadges)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
