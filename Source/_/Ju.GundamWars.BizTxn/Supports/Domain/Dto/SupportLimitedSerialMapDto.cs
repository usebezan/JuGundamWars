using Ju.GundamWars.BizMaster.Serials.Domain;

namespace Ju.GundamWars.BizTxn.Supports.Domain.Dto;

public class SupportLimitedSerialMapDto
{

    #region Primitives

    public int SupportId { get; set; }
    public int SerialId { get; set; }

    #endregion

    #region Navigations

    public SupportDto? Support { get; set; }
    public SerialDto? Serial { get; set; }

    #endregion

}
