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
    [JsonDerivedType(typeof(Longsword), "longsword")]
    [JsonDerivedType(typeof(Dagger), "dagger")]
    [JsonDerivedType(typeof(Bow), "bow")]
    [JsonDerivedType(typeof(Hammer), "hammer")]
    [JsonDerivedType(typeof(Spear), "spear")]
    [JsonDerivedType(typeof(SmallShield), "smallshield")]
    [JsonDerivedType(typeof(MediumShield), "mediumshield")]
    [JsonDerivedType(typeof(LeatherArmor), "leatherarmor")]
    [JsonDerivedType(typeof(PlateArmor), "platearmor")]
    public interface IEquippable : IItem
    {
        void Equip(ICharacter character);
        void Unequip(ICharacter character);
        EquipmentSlot Slot { get; }
    }
}