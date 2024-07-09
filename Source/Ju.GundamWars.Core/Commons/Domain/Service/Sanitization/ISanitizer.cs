namespace Ju.GundamWars.Commons.Domain.Service.Sanitization;

public interface ISanitizer<T>
{
    T Sanitize(T data);
}
