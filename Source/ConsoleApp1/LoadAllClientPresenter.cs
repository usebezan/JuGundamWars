using Ju.GundamWars.BizMaster.MobileSSkills.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.PilotSkills.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;

namespace ConsoleApp1;

internal class LoadAllClientPresenter(
    MobileSSkillInventory mobileSSkills,
    PilotAbilityInventory pilotAbilities,
    PilotSkillInventory pilotSkills,
    SerialInventory serials,
    SkillInventory skills,
    SupportBadgeInventory supportBadges,
    SupportSlotInventory supportSlots
    ) : ILoadAllClientPresenter
{
    public void ShowProgress()
    {
        Console.WriteLine("*** ShowProgress ***");
    }
    public void CloseProgress()
    {
        Console.WriteLine("*** CloseProgress ***");
    }
    public void Complete()
    {
        Console.WriteLine("*** Complete ***");
    }

    public void CompleteMobileSSkill(List<MobileSSkill> output)
    {
        Console.WriteLine("CompleteMobileSSkill");
        foreach (var item in output)
        {
            mobileSSkills.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompletePilotAbility(List<PilotAbility> output)
    {
        Console.WriteLine("CompletePilotAbility");
        foreach (var item in output)
        {
            pilotAbilities.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompletePilotSkill(List<PilotSkill> output)
    {
        Console.WriteLine("CompletePilotSkill");
        foreach (var item in output)
        {
            pilotSkills.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSerial(List<Serial> output)
    {
        Console.WriteLine("CompleteSerial");
        foreach (var item in output)
        {
            serials.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSkill(List<Skill> output)
    {
        Console.WriteLine("CompleteSkill");
        foreach (var item in output)
        {
            skills.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportBadge(List<SupportBadge> output)
    {
        Console.WriteLine("CompleteSupportBadge");
        foreach (var item in output)
        {
            supportBadges.Add(item);
            Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportSlot(List<SupportSlot> output)
    {
        Console.WriteLine("CompleteSupportSlot");
        foreach (var item in output)
        {
            supportSlots.Add(item);
            Console.WriteLine(item.ToString());
        }
    }
}
