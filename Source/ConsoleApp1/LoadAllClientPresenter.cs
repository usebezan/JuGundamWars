using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Client.Tags.Domain;

namespace ConsoleApp1;

internal class LoadAllClientPresenter(
    MobileSSkillInventory mobileSSkills,
    PilotAbilityInventory pilotAbilities,
    PilotSkillInventory pilotSkills,
    SerialInventory serials,
    SkillInventory skills,
    SupportBadgeInventory supportBadges,
    SupportSlotInventory supportSlots,
    TagInventory tags
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
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompletePilotAbility(List<PilotAbility> output)
    {
        Console.WriteLine("CompletePilotAbility");
        foreach (var item in output)
        {
            pilotAbilities.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompletePilotSkill(List<PilotSkill> output)
    {
        Console.WriteLine("CompletePilotSkill");
        foreach (var item in output)
        {
            pilotSkills.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSerial(List<Serial> output)
    {
        Console.WriteLine("CompleteSerial");
        foreach (var item in output)
        {
            serials.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSkill(List<Skill> output)
    {
        Console.WriteLine("CompleteSkill");
        foreach (var item in output)
        {
            skills.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportBadge(List<SupportBadge> output)
    {
        Console.WriteLine("CompleteSupportBadge");
        foreach (var item in output)
        {
            supportBadges.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportSlot(List<SupportSlot> output)
    {
        Console.WriteLine("CompleteSupportSlot");
        foreach (var item in output)
        {
            supportSlots.Add(item);
            //Console.WriteLine(item.ToString());
        }
    }


    public void CompleteVersioning(string output)
    {

    }

    public void CompleteTag(List<Tag> output)
    {
        Console.WriteLine("CompleteTag");
        foreach (var item in output)
        {
            tags.Add(item);
            //Console.WriteLine($"{item.Id} {item.GroupText} {item.Name} {item.Order}");
        }
    }

}
