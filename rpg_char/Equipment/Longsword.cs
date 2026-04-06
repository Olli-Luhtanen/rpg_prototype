using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Longsword : IWeapon
    {
        //Base info
        string IItem.Name => "Longsword";
        string IItem.Description => "A versatile melee weapon that can be used with one or two hands.";
        float IItem.Weight => 3.0f;
        int IItem.Value => 15;

        //Equipment info
        public EquipmentSlot Slot => EquipmentSlot.Weapon_1;
        public void Equip(ICharacter character)
        {

        }
        public void Unequip(ICharacter character)
        {

        }

        //Weapon info
        public DamageType DamageType => DamageType.Slashing;
        public Dice Damage => new Dice(1, 8);
        public Dice? VersatileDamage => new Dice(1, 10);

        public WeaponProperty WeaponProperty => WeaponProperty.Versatile;
    }
}