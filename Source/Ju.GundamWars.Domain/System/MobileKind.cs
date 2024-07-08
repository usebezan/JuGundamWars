using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record MobileKind(MobileKindType Type) : TypeRecord<MobileKindType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
