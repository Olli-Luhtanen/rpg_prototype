using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public abstract class CharacterClass
    {
        public string Name { get; }
        public Dice HitDice { get; }

        protected CharacterClass(string name, Dice hitdice) 
        {
            Name = name;
            HitDice = hitdice;
        }
    }

    class Warrior : CharacterClass
    {
        public Warrior() : base("Warrior", new Dice(1,10)) { }
    }
    class Mage : CharacterClass
    {
        public Mage() : base("Mage", new Dice(1,6)) { }
    }
    class Bard : CharacterClass
    {
        public Bard() : base("Bard", new Dice(1,8)) { }
    }
    class Ranger : CharacterClass
    {
        public Ranger() : base("Ranger", new Dice(1,8)) { }
    }
}