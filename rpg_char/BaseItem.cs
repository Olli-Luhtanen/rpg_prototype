using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public abstract class BaseItem : IItem
    {
        public string Name { get; }
        public string Description { get; }
        public float Weight { get; }
        public int Value { get; }

        protected BaseItem(string name, string description, float weight, int value)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
        }
    }
}