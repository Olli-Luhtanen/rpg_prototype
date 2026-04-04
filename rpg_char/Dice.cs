using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public struct Dice
    {
        public int Count { get; }
        public int Sides { get; }

        private static readonly Random _random = new Random();

        public Dice(int count, int sides)
        {
            if (count < 1) throw new ArgumentException("Count must be at least 1");
            if (sides < 2) throw new ArgumentException("Sides must be at least 2");
            Count = count;
            Sides = sides;
        }

        public int Roll() => _random.Next(Count, Count * Sides + 1);

        public override string ToString() => $"{Count}d{Sides}";
    }
}