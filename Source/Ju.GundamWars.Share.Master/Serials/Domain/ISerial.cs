using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Share.Serials.Domain;

public interface ISerial : IIdentify, IOrderable
{

    #region Primitives

    string Name { get; set; }

    #endregion

}
