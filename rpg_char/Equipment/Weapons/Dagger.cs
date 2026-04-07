using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Dagger : Weapon
    {
        public Dagger() : base(
            name: "Dagger",
            description: "A small blade, easy to conceal and quick to draw.",
            weight: 0.5f,
            value: 10,
            damage: new List<DamageComponent> { new DamageComponent(new Dice(1, 4), DamageType.Piercing) },
            properties: WeaponProperty.Finesse | WeaponProperty.Thrown
        )
        { }
    }
}