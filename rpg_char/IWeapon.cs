using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface IWeapon : IEquipable, IItem
    {
        DamageType DamageType { get; }
        Dice Damage { get; }
        Dice? VersatileDamage { get; }
        WeaponProperty WeaponProperty { get; }
    }
}