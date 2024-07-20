namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobilePairMap
{

    public int MobileId { get; set; }
    public int PairId { get; set; }

    public Mobile? Mobile { get; set; }
    public Mobile? Pair { get; set; }

}
