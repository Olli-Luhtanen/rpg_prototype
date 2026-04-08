using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public class Weapon : BaseItem, IWeapon
    {
        public List<DamageComponent> Damage { get; set; }
        public WeaponProperty Properties { get; set; }
        public EquipmentSlot Slot { get; set; }
        public List<DamageComponent>? VersatileDamage { get; set; }

        [JsonConstructor]
        public Weapon(string name, string description, float weight, int value,
                    List<DamageComponent> damage, WeaponProperty properties, EquipmentSlot slot = EquipmentSlot.Weapon_1, List<DamageComponent>? versatileDamage = null)
                    : base(name, description, weight, value)
        {
            Damage = damage;
            Properties = properties;
            Slot = slot;
            VersatileDamage = versatileDamage;
        }

        public void Equip(ICharacter character)
        {
            IEquippable? current = character.GetEquipped(Slot);
            if (current != null)
                character.AddToInventory(current);

            if ((Properties & WeaponProperty.TwoHanded) != 0)
                character.Unequip(EquipmentSlot.Weapon_2);
        }
        public void Unequip(ICharacter character)
        {
            character.AddToInventory(this);
        }

        //TODO: Check if the versitile or two hand is checked correctly
        public virtual int RollDamage(bool twoHanded = false)
        {
            if (twoHanded && (Properties & WeaponProperty.Versatile) != 0 && VersatileDamage != null)
                return VersatileDamage.Sum(d => d.Dice.Roll());
            return Damage.Sum(d => d.Dice.Roll());
        }

        public override string ToString() => $"{Name} - {string.Join(", ", Damage)} {Properties} | {Value}g {Weight}kg";
    }
}