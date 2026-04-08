using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public class Armor : BaseItem, IArmor
    {
        public int ArmorRating { get; set; }
        public EquipmentSlot Slot { get; set; }

        [JsonConstructor]
        public Armor(string name, string description, float weight, int value,
                     int armorRating, EquipmentSlot slot)
                    :base(name, description, weight, value)
        {
            ArmorRating = armorRating;
            Slot = slot;
        }

        public void Equip(ICharacter character){
            IEquippable? current = character.GetEquipped(Slot);
            if (current != null)
                character.AddToInventory(current);
        }
        public void Unequip(ICharacter character){
            character.AddToInventory(this);
        }

        public override string ToString() => $"{Name} - {ArmorRating} AC | {Value}g {Weight}kg";
    }
}