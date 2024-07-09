namespace Ju.GundamWars.Domain.Common.Gateway;

public interface IByIdGateway<T> : ISelectByIdGateway<T>, IInsertGateway<T>, IUpdateGateway<T>, IDeleteByIdGateway<T>
    where T : class
{
}
