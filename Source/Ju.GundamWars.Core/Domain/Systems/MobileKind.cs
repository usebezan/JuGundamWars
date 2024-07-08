using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record MobileKind(MobileKindType Type) : TypeRecord<MobileKindType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
