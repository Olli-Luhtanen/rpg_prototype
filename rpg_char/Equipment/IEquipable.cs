using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    // This interface has common methods of equipable gear and atributes like name, value and such.
    public interface IEquipable
    {
        void Equip(ICharacter character);
        void Unequip(ICharacter character);
        EquipmentSlot Slot { get; }
    }
}