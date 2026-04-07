using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Weapon), "weapon")]
    [JsonDerivedType(typeof(Armor), "armor")]
    [JsonDerivedType(typeof(Shield), "shield")]
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        float Weight { get; }
        int Value { get; }
    }
}