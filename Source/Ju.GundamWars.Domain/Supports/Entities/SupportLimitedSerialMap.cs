using Ju.GundamWars.Domain.Serials.Dto;

namespace Ju.GundamWars.Domain.Supports.Entities;

public class SupportLimitedSerialMap
{

    public int SupportId { get; set; }
    public int SerialId { get; set; }

    public Support? Support { get; set; }
    public Serial? Serial { get; set; }

}
