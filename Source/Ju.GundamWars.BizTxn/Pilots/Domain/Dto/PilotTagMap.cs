using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Dto;

public class PilotTagMap
{

    public int PilotId { get; set; }
    public int TagId { get; set; }

    public Pilot? Pilot { get; set; }
    public Tag? Tag { get; set; }

}
