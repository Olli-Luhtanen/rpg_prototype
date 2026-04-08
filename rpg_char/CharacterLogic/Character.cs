using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public class Character : ICharacter
    {
        public string Name { get; private set; }
        public int Level { get; private set; }

        public int MaxHP => Class.HitDice.Sides;
        public int CurrentHP { get; private set; }


        [JsonPropertyName("class")]
        public CharacterClass Class { get; private set; }
        public CharacterStats Stats { get; private set; }


        public List<IItem> Inventory { get; set; } = new List<IItem>();

        [JsonConstructor]
        public Character(string name, CharacterClass @class, int level = 1, CharacterStats? stats = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = @class ?? throw new ArgumentNullException(nameof(@class));
            Level = Math.Max(1, level);
            Stats = stats ?? new CharacterStats();

            CurrentHP = MaxHP;
        }

        // Inventory
        public void AddToInventory(IItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Inventory.Add(item);
        }
        public bool RemoveFromInventory(IItem item)
        {
            if (item == null) return false;
            return Inventory.Remove(item);
        }


        // Equipment + slot managment
        private readonly IEquippable?[] _equippedSlots = new IEquippable?[Enum.GetValues<EquipmentSlot>().Length];
        public List<IEquippable?> EquippedItems
        {
            get => _equippedSlots.ToList();
            set
            {
                for (int i = 0; i < value.Count && i < _equippedSlots.Length; i++)
                    _equippedSlots[i] = value[i];
            }
        }
        public IEquippable? GetEquipped(EquipmentSlot slot) => _equippedSlots[(int)slot];

        public void Equip(IEquippable item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (!Inventory.Contains(item)) throw new InvalidOperationException("Item must be in inventory to equip.");

            int slotIndex = (int)item.Slot;
            if (slotIndex < 0 || slotIndex >= _equippedSlots.Length)
                throw new ArgumentOutOfRangeException(nameof(item.Slot), "Invalid equipment slot.");

            var previousItem = _equippedSlots[slotIndex];
            if (previousItem != null)
            {
                previousItem.Unequip(this);
                Inventory.Add(previousItem);
            }

            Inventory.Remove(item);
            _equippedSlots[(int)item.Slot] = item;
            item.Equip(this);
        }
        public void Unequip(EquipmentSlot slot)
        {
            int idx = (int)slot;
            if (idx < 0 || idx >= _equippedSlots.Length) throw new ArgumentOutOfRangeException(nameof(slot));

            var item = _equippedSlots[idx];
            if (item == null) return;

            _equippedSlots[(int)slot]?.Unequip(this);
            _equippedSlots[(int)slot] = null;
        }

        // Armor Class calc
        public int TotalDefense() => _equippedSlots
            .OfType<IDefensive>()
            .Sum(d => d.ArmorRating);


        //Health management
        public void TakeDamage(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            CurrentHP = Math.Max(0, CurrentHP - amount);
        }
        public void Heal(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            CurrentHP = Math.Min(MaxHP, CurrentHP + amount);
        }
        public bool IsAlive => CurrentHP > 0;

        public override string ToString() => $"{Name} | {Class.Name} Level {Level} | HP: {CurrentHP}/{MaxHP} | AC: {TotalDefense()}";
    }
}