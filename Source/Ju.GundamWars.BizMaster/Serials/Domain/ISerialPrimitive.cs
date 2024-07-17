using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.Serials.Domain;

public interface ISerialPrimitive : IIdentify, IOrderable
{

    #region Primitives

    string Name { get; set; }

    #endregion

}
