using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Spear : Weapon
    {
        public Spear() : base(
            name: "Spear",
            description: "A long reach weapon, can be thrown or used both one or two handed.",
            weight: 3.0f,
            value: 20,
            damage: new List<DamageComponent> { new DamageComponent(new Dice(1, 6), DamageType.Piercing) },
            properties: WeaponProperty.Thrown | WeaponProperty.Versatile | WeaponProperty.Reach,
            versatileDamage: new List<DamageComponent> { new DamageComponent(new Dice(1, 8), DamageType.Piercing) }
        )
        { }
    }
}