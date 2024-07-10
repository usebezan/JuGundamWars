using Ju.GundamWars.Biz.Pilots.Domain.Entities;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Entities;

public class MobilePilotMap
{

    public int MobileId { get; set; }
    public int PilotId { get; set; }

    public Mobile? Mobile { get; set; }
    public Pilot? Pilot { get; set; }

}
