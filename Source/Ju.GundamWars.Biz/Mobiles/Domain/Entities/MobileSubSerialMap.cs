using Ju.GundamWars.Core.Ju.GundamWars.Masters.Serials.Dto;

namespace Ju.GundamWars.Mobiles.Domain.Entities;

public class MobileSubSerialMap
{

    public int MobileId { get; set; }
    public int SerialId { get; set; }

    public Mobile? Mobile { get; set; }
    public Serial? Serial { get; set; }

}
