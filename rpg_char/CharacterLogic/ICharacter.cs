using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface ICharacter : IHealth
    {
        string Name { get; }
        CharacterClass Class { get; }
        int Level { get; }
        CharacterStats Stats { get; }
        IReadOnlyList<IItem> Inventory { get; }

        IEquippable? GetEquipped(EquipmentSlot slot);
        void Equip(IEquippable item);
        void Unequip(EquipmentSlot slot);
        void AddToInventory(IItem item);
    }
}