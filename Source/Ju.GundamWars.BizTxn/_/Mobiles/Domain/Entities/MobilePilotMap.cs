using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;

public class MobilePilotMap
{

    public int MobileId { get; set; }
    public int PilotId { get; set; }

    public Mobile? Mobile { get; set; }
    public PilotDto? Pilot { get; set; }

}
