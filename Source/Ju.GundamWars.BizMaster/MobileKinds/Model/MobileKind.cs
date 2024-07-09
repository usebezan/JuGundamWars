using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.MobileKinds.Model;

public record MobileKind(MobileKindType Type) : TypeRecord<MobileKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
