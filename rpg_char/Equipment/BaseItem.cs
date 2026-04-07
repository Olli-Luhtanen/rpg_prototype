using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace rpg_char
{
    public abstract class BaseItem : IItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Value { get; set; }

        [JsonConstructor]
        protected BaseItem(string name, string description, float weight, int value)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
        }
    }
}