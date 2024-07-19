using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Share.AceImpls.Domain;

public record AceImpl(AceImplType Type) : TypeRecord<AceImplType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
