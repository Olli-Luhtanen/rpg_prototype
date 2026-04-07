using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public class DamageComponent
    {
        public Dice Dice { get; }
        public DamageType Type { get; }

        public DamageComponent(Dice dice, DamageType type)
        {
            Dice = dice;
            Type = type;
        }
    }
}