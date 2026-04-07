using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface IEquippable : IItem
    {
        void Equip(ICharacter character);
        void Unequip(ICharacter character);
        EquipmentSlot Slot { get; }
    }
}