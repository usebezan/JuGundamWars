using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Client.MobileSSkills.Domain;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Ju.GundamWars.Client.Tags.Domain;
using System.Diagnostics;

namespace ConsoleApp1.Presentation;

internal class LoadAllClientPresenter(
    MobileSSkillInventory mobileSSkills,
    PilotAbilityInventory pilotAbilities,
    PilotSkillInventory pilotSkills,
    SerialInventory serials,
    SkillInventory skills,
    SupportBadgeInventory supportBadges,
    SupportSlotInventory supportSlots,
    CoMobileInventory coMobiles,
    CuspaInventory cuspas,
    PilotInventory pilots,
    TagInventory tags) : ILoadAllClientPresenter
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
    public void Complete()
    {
        Console.WriteLine("*** Complete ***");
    }

    public void CompleteMobileSSkill(List<MobileSSkill> output)
    {
        Console.WriteLine("*** CompleteMobileSSkill ***");
        foreach (var item in output)
        {
            mobileSSkills.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompletePilotAbility(List<PilotAbility> output)
    {
        Console.WriteLine("*** CompletePilotAbility ***");
        foreach (var item in output)
        {
            pilotAbilities.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompletePilotSkill(List<PilotSkill> output)
    {
        Console.WriteLine("*** CompletePilotSkill ***");
        foreach (var item in output)
        {
            pilotSkills.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompleteSerial(List<Serial> output)
    {
        Console.WriteLine("*** CompleteSerial ***");
        foreach (var item in output)
        {
            serials.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompleteSkill(List<Skill> output)
    {
        Console.WriteLine("*** CompleteSkill ***");
        foreach (var item in output)
        {
            skills.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportBadge(List<SupportBadge> output)
    {
        Console.WriteLine("*** CompleteSupportBadge ***");
        foreach (var item in output)
        {
            supportBadges.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }

    public void CompleteSupportSlot(List<SupportSlot> output)
    {
        Console.WriteLine("*** CompleteSupportSlot ***");
        foreach (var item in output)
        {
            supportSlots.Add(item);
            Debug.WriteLine(item.ToString());
        }
    }


    public void CompleteVersioning(string output)
    {
        Console.WriteLine("*** CompleteVersioning ***");
    }

    public void CompleteTag(List<Tag> output)
    {
        Console.WriteLine("*** CompleteTag ***");
        foreach (var item in output)
        {
            tags.Add(item);
            Debug.WriteLine($"{item.Id} {item.TagGroupText} {item.Name} {item.Order}");
        }
    }

    public void CompleteCoMobile(List<CoMobile> output)
    {
        Console.WriteLine("*** CompleteCoMobile ***");
        foreach (var item in output)
        {
            coMobiles.Add(item);
            Debug.WriteLine($"{item.Id} {item.Name}");
            foreach (var tag in item.Tags)
            {
                Debug.WriteLine($"  {tag.Id} {tag.Name}");
            }
        }
    }

    public void CompleteCuspa(List<Cuspa> output)
    {
        Console.WriteLine("*** CompleteCuspa ***");
        foreach (var item in output)
        {
            cuspas.Add(item);
            Debug.WriteLine($"{item.Id} {item.Name}");
            foreach (var tag in item.Tags)
            {
                Debug.WriteLine($"  {tag.Id} {tag.Name}");
            }
        }
    }

    public void CompletePilot(List<Pilot> output)
    {
        Console.WriteLine("*** CompletePilot ***");
        foreach (var item in output)
        {
            pilots.Add(item);
            Debug.WriteLine($"{item.Id} {item.Name}");
            foreach (var slotAbility in item.PilotSlotAbilities.Where(m => m.PilotAbility != null))
            {
                Debug.WriteLine($"  {slotAbility.Seq} {slotAbility.SlotRank} {slotAbility.PilotAbility?.Name}");
            }
            foreach (var tag in item.Tags)
            {
                Debug.WriteLine($"  {tag.Id} {tag.Name}");
            }
        }
    }

}
