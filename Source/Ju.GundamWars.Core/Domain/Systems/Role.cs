using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Role(RoleType Type) : TypeRecord<RoleType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
