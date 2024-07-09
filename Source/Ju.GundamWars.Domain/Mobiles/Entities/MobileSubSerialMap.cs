using Ju.GundamWars.Domain.Serials.Dto;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileSubSerialMap
{

    public int MobileId { get; set; }
    public int SerialId { get; set; }

    public Mobile? Mobile { get; set; }
    public Serial? Serial { get; set; }

}
