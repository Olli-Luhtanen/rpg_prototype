using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class LeatherArmor : Armor
    {
        public LeatherArmor() : base(
            name: "Leather Armor",
            description: "A suit of armor made from hardened leather, offering basic protection while allowing for good mobility.",
            weight: 10.0f,
            value: 25,
            armorRating: 11,
            slot: EquipmentSlot.Chest
        )
        {}
    }
}