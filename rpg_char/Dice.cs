using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public readonly struct Dice
    {
        public int Count { get; }
        public int Sides { get; }

        [JsonConstructor]
        public Dice(int count, int sides)
        {
            if (count < 1) throw new ArgumentException("Count must be at least 1");
            if (sides < 2) throw new ArgumentException("Sides must be at least 2");
            Count = count;
            Sides = sides;
        }

        public int Roll()
        {
            int total = 0;
            for (int i = 0; i < Count; i++)
            {
                total += Random.Shared.Next(1, Sides + 1);
            }
            return total;
        }

        public override string ToString() => $"{Count}d{Sides}";
    }
}