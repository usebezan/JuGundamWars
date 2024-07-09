using Ju.GundamWars.Pilots.Domain.Entities;

namespace Ju.GundamWars.Mobiles.Domain.Entities;

public class MobilePilotMap
{

    public int MobileId { get; set; }
    public int PilotId { get; set; }

    public Mobile? Mobile { get; set; }
    public Pilot? Pilot { get; set; }

}
