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
        public int MaxHP => Class.HitDice.Sides + (Stats.Constitution * Level);
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


        // Equipment
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
            Inventory.Remove(item);
            _equippedSlots[(int)item.Slot] = item;
            item.Equip(this);
        }
        public void Unequip(EquipmentSlot slot)
        {
            _equippedSlots[(int)slot]?.Unequip(this);
            _equippedSlots[(int)slot] = null;
        }

        // Armor Class calculation
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
    }
}