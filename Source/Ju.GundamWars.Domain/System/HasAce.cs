using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record HasAce(HasAceType Type) : TypeRecord<HasAceType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
