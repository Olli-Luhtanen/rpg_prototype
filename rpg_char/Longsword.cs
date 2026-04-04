using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Longsword : IWeapon
    {
        //Base info
        string IItem.Name()
        {
            return "Longsword";
        }
        string IItem.Description()
        {
            return "";
        }
        int IItem.Value()
        {
            return 15;
        }
        float IItem.Weight()
        {
            return 3.0f;
        }

        //Equipment info
        void IEquipable.Slot()
        {
            // Implementation for equipping the longsword in the appropriate slot (e.g., main hand)
        }
        public void Equip(Character character)
        {

        }
        public void Unequip(Character character)
        {

        }

        //Weapon info
        public DamageType DamageType => DamageType.Slashing;
        public Dice Damage => new Dice(1, 8);
        public Dice? VersatileDamage => new Dice(1, 10);

        public WeaponProperty WeaponProperty => WeaponProperty.Versatile;
    }
}