using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.Biz.Pilots.Domain.Entities;

public class PilotTagMap
{

    public int PilotId { get; set; }
    public int TagId { get; set; }

    public Pilot? Pilot { get; set; }
    public Tag? Tag { get; set; }

}
