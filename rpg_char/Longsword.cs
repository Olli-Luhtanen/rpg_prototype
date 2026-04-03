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
        public string Description { get; }
        public int Value { get; }
        public float Weight { get; }

        //Equipment info
        public EquipmentSlot Slot => EquipmentSlot.MainHand;
        public void Equip(Character character)
        {

        }
        public void Unequip(Character character)
        {

        }

        //Weapon info
        public WeaponProperty Properties {  get; }

    }
}