namespace Ju.GundamWars.Domain.Common.Model;

public record TypeRecord<T>(T Type, byte Value, string Name, string General) where T : Enum { }

public record TypeRecord2<T>(T Type, int Value, string Name, string General) where T : Enum { }
