namespace Ju.GundamWars.Commons.Domain.Service.Validation;

public interface IValidator<T>
{
    void Validate(T data);
}
