using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public class DamageComponent
    {
        public Dice Dice { get; set; }
        public DamageType Type { get; set; }

        [JsonConstructor]
        public DamageComponent(Dice dice, DamageType type)
        {
            Dice = dice;
            Type = type;
        }

        public override string ToString() => $"{Dice} {Type}";
    }
}