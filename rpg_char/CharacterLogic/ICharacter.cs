using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rpg_char
{
    public interface ICharacter
    {
        string Name { get; }
        CharacterClass Class { get; }
        int Level { get; }
        CharacterStats Stats { get; }
        IReadOnlyList<IItem> Inventory { get; }
    }
}