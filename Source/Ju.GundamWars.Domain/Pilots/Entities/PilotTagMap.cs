using Ju.GundamWars.Domain.Tags.Dto;

namespace Ju.GundamWars.Domain.Pilots.Entities;

public class PilotTagMap
{

    public int PilotId { get; set; }
    public int TagId { get; set; }

    public Pilot? Pilot { get; set; }
    public Tag? Tag { get; set; }

}
