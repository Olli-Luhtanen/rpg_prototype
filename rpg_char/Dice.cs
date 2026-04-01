using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public struct Dice
    {
        int Count;
        int Sides;
        private static readonly Random _random = new Random();
        public int Roll() => _random.Next(Count, Count*Sides +1);
        
    }
}