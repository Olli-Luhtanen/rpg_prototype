using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int MaxHP => Class.HitDice.Sides + (Stats.Constitution * Level);
        public int CurrentHP { get; private set; }

        public CharacterClass Class { get; private set; }
        public CharacterStats Stats { get; private set; }


        private readonly List<IItem> _inventory = new List<IItem>();
        public IReadOnlyList<IItem> Inventory => _inventory.AsReadOnly();

        public Character(string name, CharacterClass characterClass, int level = 1, CharacterStats? stats = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = characterClass ?? throw new ArgumentNullException(nameof(characterClass));
            Level = Math.Max(1, level);
            Stats = stats ?? new CharacterStats();
        }

        // Inventory
        public void AddToInventory(IItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            _inventory.Add(item);
        }
        public bool RemoveFromInventory(IItem item)
        {
            if (item == null) return false;
            return _inventory.Remove(item);
        }


        // Equipment
        private readonly IEquippable?[] _equippedSlots = new IEquippable?[Enum.GetValues<EquipmentSlot>().Length];
        public IEquippable? GetEquipped(EquipmentSlot slot) => _equippedSlots[(int)slot];

        public void Equip(IEquippable item)
        {
            _inventory.Remove(item);
            _equippedSlots[(int)item.Slot] = item;
            item.Equip(this);
        }
        public void Unequip(EquipmentSlot slot)
        {
            _equippedSlots[(int)slot]?.Unequip(this);
            _equippedSlots[(int)slot] = null;
        }

        public int TotalDefense() => _equippedSlots
            .OfType<IDefensive>()
            .Sum(d => d.ArmorRating);
    }
}