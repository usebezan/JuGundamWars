using Ju.GundamWars.BizTxn.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;

public class CoMobileTagMapDto
{

    #region Primitives

    public int CoMobileId { get; set; }
    public int TagId { get; set; }

    #endregion

    #region Navigations

    public CoMobileDto? CoMobile { get; set; }
    public TagDto? Tag { get; set; }

    #endregion

}
