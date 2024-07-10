using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.AceImpls.Domain.Model;

public record AceImpl(AceImplType Type) : TypeRecord<AceImplType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
