using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record Role(RoleType Type) : TypeRecord<RoleType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
