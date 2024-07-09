using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.AceImpls.Model;

public record AceImpl(AceImplType Type) : TypeRecord<AceImplType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
