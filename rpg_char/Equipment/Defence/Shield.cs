using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Shield : BaseItem, IShield
    {
        public EquipmentSlot Slot => EquipmentSlot.Weapon_2;
        public int ArmorRating { get; }

        public Shield(string name, string description, float weight, int value,
                      int armorRating): base(name, description, weight, value)
        {
            ArmorRating = armorRating;
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