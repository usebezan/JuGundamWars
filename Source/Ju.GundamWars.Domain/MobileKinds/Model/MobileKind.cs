using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.MobileKinds.Model;

public record MobileKind(MobileKindType Type) : TypeRecord<MobileKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
