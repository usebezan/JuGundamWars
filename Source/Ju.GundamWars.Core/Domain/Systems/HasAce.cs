using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record HasAce(HasAceType Type) : TypeRecord<HasAceType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
