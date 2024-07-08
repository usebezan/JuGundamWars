using Ju.GundamWars.Domain.System.Entities;

namespace Ju.GundamWars.Domain.Supports.Entities;

public class SupportLimitedSerialMap
{

    public int SupportId { get; set; }
    public int SerialId { get; set; }

    public Support? Support { get; set; }
    public Serial? Serial { get; set; }

}
