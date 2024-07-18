using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public interface IVersioningPrimitive : IIdentify
{

    #region Primitives

    string Version { get; set; }

    #endregion

}
