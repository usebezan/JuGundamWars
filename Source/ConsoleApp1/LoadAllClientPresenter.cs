using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
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
    public void Complete()
    {
    }

    public void CompletePilotAbility(List<PilotAbility> output)
    {
        Console.WriteLine("CompletePilotAbility");
        foreach (var item in output)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSerial(List<Serial> output)
    {
        Console.WriteLine("CompleteSerial");
        foreach (var item in output)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSkill(List<Skill> output)
    {
        Console.WriteLine("CompleteSkill");
        foreach (var item in output)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportBadge(List<SupportBadge> output)
    {
        Console.WriteLine("CompleteSupportBadge");
        foreach (var item in output)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportSlot(List<SupportSlot> output)
    {
        Console.WriteLine("CompleteSupportSlot");
        foreach (var item in output)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
