using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Weapon : BaseItem, IWeapon
    {
        public List<DamageComponent> Damage { get; }
        public WeaponProperty Properties { get; }
        public EquipmentSlot Slot { get; }
        public List<DamageComponent>? VersatileDamage { get; }

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
        public void Unequip(ICharacter character){
            character.AddToInventory(this);
        }

        public int RollDamage() => Damage.Sum(d => d.Dice.Roll());
    }
}