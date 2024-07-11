using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizConst.MobileKinds.Domain;

public record MobileKind(MobileKindType Type) : TypeRecord<MobileKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
