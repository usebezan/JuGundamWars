using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record Category(CategoryType Type) : TypeRecord<CategoryType>(Type, Type.ToValue(), Type.ToText(), Type.ToIcon())
{
    public string Icon => General;
}
