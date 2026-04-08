using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class Bow : Weapon
    {
        public Bow() : base(
            name: "Longbow",
            description: "A tall bow requiring significant strength to draw.",
            weight: 2.0f,
            value: 35,
            damage: new List<DamageComponent> { new DamageComponent(new Dice(1, 8), DamageType.Piercing) },
            properties: WeaponProperty.TwoHanded | WeaponProperty.Ranged,
            slot: EquipmentSlot.Weapon_1
        )
        { }
        public override int RollDamage(bool twoHanded = true) => Damage.Sum(d => d.Dice.Roll());
    }
}