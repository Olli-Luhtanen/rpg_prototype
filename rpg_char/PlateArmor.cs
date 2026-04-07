using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class PlateArmor : Armor
    {
        public PlateArmor() : base(
            name: "Plate Armor",
            description: "A full suit of heavy armor made from interlocking metal plates, providing excellent protection.",
            weight: 50.0f,
            value: 200,
            armorRating: 18,
            slot: EquipmentSlot.Chest
        )
        { }
    }
}