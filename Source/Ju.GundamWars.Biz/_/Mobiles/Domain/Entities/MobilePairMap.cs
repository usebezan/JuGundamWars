namespace Ju.GundamWars.Biz._.Mobiles.Domain.Entities;

public class MobilePairMap
{

    public int MobileId { get; set; }
    public int PairId { get; set; }

    public Mobile? Mobile { get; set; }
    public Mobile? Pair { get; set; }

}
