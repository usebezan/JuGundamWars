using Ju.GundamWars.BizTxn.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn.Supports.Domain.Dto;

public class SupportTagMapDto
{

    #region Primitives

    public int SupportId { get; set; }
    public int TagId { get; set; }

    #endregion

    #region Navigations

    public SupportDto? Support { get; set; }
    public TagDto? Tag { get; set; }

    #endregion

}
