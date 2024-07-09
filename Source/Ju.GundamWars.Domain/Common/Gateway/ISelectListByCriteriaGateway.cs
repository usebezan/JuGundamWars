namespace Ju.GundamWars.Domain.Common.Gateway;

public interface ISelectListByCriteriaGateway<TCriteria, T>
    where T : class
{
    Task<List<T>> SelectListByCriteriaAsync(TCriteria criteria);
}
