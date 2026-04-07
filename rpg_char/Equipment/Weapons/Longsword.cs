using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Longsword : Weapon
    {
        public Longsword() : base(
                name: "Longsword",
                description: "A versatile straight blade, well balanced for both one and two handed use.",
                weight: 3.5f,
                value: 50,
                damage: new List<DamageComponent> { new DamageComponent(new Dice(1, 8), DamageType.Slashing) },
                properties: WeaponProperty.Versatile,
                versatileDamage: new List<DamageComponent> { new DamageComponent(new Dice(1, 10), DamageType.Slashing) }
            )
        { }
    }
}