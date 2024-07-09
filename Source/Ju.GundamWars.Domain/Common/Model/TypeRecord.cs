namespace Ju.GundamWars.Domain.Common.Model;

public record TypeRecord<T, TValue>(T Type, TValue Value, string Name)
    where T : Enum
{
}
