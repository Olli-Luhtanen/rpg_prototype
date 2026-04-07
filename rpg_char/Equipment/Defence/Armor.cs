using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Armor : BaseItem, IArmor
    {
        public EquipmentSlot Slot { get; }
        public int ArmorRating { get; }

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
    }
}