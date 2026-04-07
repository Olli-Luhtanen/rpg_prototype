using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Hammer : Weapon
    {
        public Hammer() : base(
            name: "Warhammer",
            description: "A heavy hammer, capable of crushing armor and bone.",
            weight: 5.0f,
            value: 40,
            damage: new List<DamageComponent> { new DamageComponent(new Dice(1, 10), DamageType.Bludgeoning) },
            properties: WeaponProperty.TwoHanded
        )
        { }
    }
}