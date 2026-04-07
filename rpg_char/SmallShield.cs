using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class SmallShield: Shield
    {
        public SmallShield() : base(
            name: "Small Shield",
            description: "A compact shield that offers basic protection while allowing for greater mobility.",
            weight: 3.0f,
            value: 30,
            armorRating: 1
        )
        { }
    }
}