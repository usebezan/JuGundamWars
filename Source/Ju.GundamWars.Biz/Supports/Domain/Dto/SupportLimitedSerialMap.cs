using Ju.GundamWars.Core.Ju.GundamWars.Masters.Serials.Dto;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class SupportLimitedSerialMap
{

    public int SupportId { get; set; }
    public int SerialId { get; set; }

    public Support? Support { get; set; }
    public Serial? Serial { get; set; }

}
