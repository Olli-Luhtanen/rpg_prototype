using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class MediumShield : Shield
    {
        public MediumShield() : base(
            name: "Medium Shield",
            description: "A sturdy shield that offers solid protection without being too cumbersome.",
            weight: 6.0f,
            value: 55,
            armorRating: 2
        )
        { }
    }
}