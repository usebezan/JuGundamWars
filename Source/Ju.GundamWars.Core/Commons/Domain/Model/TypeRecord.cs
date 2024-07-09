namespace Ju.GundamWars.Commons.Domain.Model;

public record TypeRecord<T, TValue>(T Type, TValue Value, string Name)
    where T : Enum
{
}
